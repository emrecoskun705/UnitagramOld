using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Serilog;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Identity.Models;
using Unitagram.Identity.Services;

namespace Unitagram.Identity.UnitTests;

public class AuthServiceTests
{
    private readonly Mock<UserManager<ApplicationUser>> _userManager;
    private readonly Mock<SignInManager<ApplicationUser>> _signInManager;
    private readonly Mock<RoleManager<ApplicationRole>> _roleManager;
    private readonly Mock<IJwtService> _jwtService;
    private readonly Mock<IDiagnosticContext> _diagnosticContextMock;
    private readonly IFixture _fixture;

    public AuthServiceTests()
    {
        _fixture = new Fixture();
        // Initialize and set up your mocks here
        _userManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null,
            null, null, null, null, null);

        // Create mock objects for dependencies of SignInManager
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claimsFactoryMock = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
        var optionsAccessorMock = new Mock<IOptions<IdentityOptions>>();
        var loggerMock = new Mock<ILogger<SignInManager<ApplicationUser>>>();
        var schemesMock = new Mock<IAuthenticationSchemeProvider>();
        var confirmationMock = new Mock<IUserConfirmation<ApplicationUser>>();

        _diagnosticContextMock = new Mock<IDiagnosticContext>();

        _signInManager = new Mock<SignInManager<ApplicationUser>>(
            _userManager.Object,
            httpContextAccessorMock.Object,
            claimsFactoryMock.Object,
            optionsAccessorMock.Object,
            loggerMock.Object,
            schemesMock.Object,
            confirmationMock.Object
        );

        _roleManager =
            new Mock<RoleManager<ApplicationRole>>(Mock.Of<IRoleStore<ApplicationRole>>(), null, null, null, null);
        _jwtService = new Mock<IJwtService>();
    }
    
    private AuthService CreateAuthService()
    {
        return new AuthService(_userManager.Object, _signInManager.Object, _roleManager.Object,
            _jwtService.Object, Mock.Of<ILogger<AuthService>>(), _diagnosticContextMock.Object);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsAuthResponse()
    {
        //Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            Email = "test@example.com",
            Password = "password123",
        };
        var user = new ApplicationUser { Email = authRequest.Email };

        // Set up mock behavior
        _userManager.Setup(u => u.FindByEmailAsync(authRequest.Email)).ReturnsAsync(user);
        _signInManager.Setup(s => s.CheckPasswordSignInAsync(user, authRequest.Password, false))
            .ReturnsAsync(SignInResult.Success);
        // just return some JWT response values for test to work
        _jwtService.Setup(x => x.CreateJwtToken(It.IsAny<JwtRequest>()))
            .Returns(_fixture.Build<JwtResponse>().Create());

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IfSucc(authResponse => authResponse.Should().NotBeNull());
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsBadRequestException()
    {
        // Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            Email = "test@example.com",
            Password = "randomPassword",
        };
        var user = new ApplicationUser { Email = authRequest.Email };

        // Set up mock behavior
        _userManager.Setup(u => u.FindByEmailAsync(authRequest.Email)).ReturnsAsync(user);
        _signInManager.Setup(s => s.CheckPasswordSignInAsync(user, authRequest.Password, false))
            .ReturnsAsync(SignInResult.Failed);

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<BadRequestException>());
    }

    [Fact]
    public async Task Login_InvalidValidation_ReturnsValidationException()
    {
        // Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            Email = "test",
            Password = "randomPassword",
        };
        var user = new ApplicationUser { Email = authRequest.Email };

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<ValidationException>());
    }

    [Fact]
    public async Task Login_UserNotFound_ReturnsNotFoundException()
    {
        // Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            Email = "emre@emre.com",
            Password = "randomPassword",
        };
        // Set up mock behavior
        _userManager.Setup(u => u.FindByEmailAsync(authRequest.Email)).ReturnsAsync(null as ApplicationUser);

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<NotFoundException>());
    }
}