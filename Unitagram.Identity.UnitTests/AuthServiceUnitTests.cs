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
using Unitagram.Application.Models.Identity.Register;
using Unitagram.Identity.Models;
using Unitagram.Identity.Services;

namespace Unitagram.Identity.UnitTests;

public class AuthServiceUnitTests
{
    private readonly Mock<UserManager<ApplicationUser>> _userManager;
    private readonly Mock<SignInManager<ApplicationUser>> _signInManager;
    private readonly Mock<RoleManager<ApplicationRole>> _roleManager;
    private readonly Mock<IJwtService> _jwtService;
    private readonly Mock<IDiagnosticContext> _diagnosticContextMock;
    private readonly IFixture _fixture;

    public AuthServiceUnitTests()
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

    #region Login

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

    #endregion

    #region Register
    
    [Fact]
    public async Task Register_ValidCredentials_ReturnsRegisterResponse()
    {
        //Arrange
        var authService = CreateAuthService();
        var validRegisterRequest = new RegisterRequest()
        {
            Email = "emre@posta.mu.edu.tr",
            UserName = "emrecoskun",
            PhoneNumber = "5458413575",
            Password = "P@ssword1!",
            ConfirmPassword = "P@ssword1!",
        };   

        // Set up mock behavior
        var successIdentityResult = IdentityResult.Success;
        
        _userManager
            .Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), validRegisterRequest.Password))
            .ReturnsAsync(successIdentityResult);
        _userManager
            .Setup(u => u.UpdateAsync(It.IsAny<ApplicationUser>()));
        
        _jwtService
            .Setup(u => u.CreateJwtToken(It.IsAny<JwtRequest>()));

        // just return some JWT response values for test to work
        _jwtService.Setup(x => x.CreateJwtToken(It.IsAny<JwtRequest>()))
            .Returns(_fixture.Build<JwtResponse>().Create());
        

        // Act
        var result = await authService.Register(validRegisterRequest);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IfSucc(registerResponse => registerResponse.Should().NotBeNull());
        result.IfSucc(registerResponse => registerResponse.Should().BeOfType<RegisterResponse>());
    }

    [Theory]
    [InlineData("invalidemail", "validusername", "1234567890", "password123", "password123")] // Invalid email
    [InlineData("validemail@example.com", "validusername", "1234567890", "pass",  "password123")] // Invalid password
    [InlineData("validemail@example.com", "abc", "1234567890", "password123", "password123")] // invalid username
    [InlineData("validemail@example.com", "validusername", "invalidphone", "password123", "password123")] // invalid phone
    [InlineData("validemail@example.com", "validusername", "1234567890", "password123", "password456")] // password do not match
    public async Task Register_InvalidCredentials_ReturnsValidationException(string email, string userName, string phoneNumber, string password, string confirmPassword)
    {
        //Arrange
        var authService = CreateAuthService();
        var registerRequest = new RegisterRequest()
        {
            Email = email,
            UserName = userName,
            PhoneNumber = phoneNumber,
            Password = password,
            ConfirmPassword = confirmPassword,
        };
        
        // Act
        var result = await authService.Register(registerRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<ValidationException>());
    }

    [Fact]
    public async Task Register_UserManagerCreateFail_ReturnsBadRequestException()
    {
        //Arrange
        var authService = CreateAuthService();
        var validRegisterRequest = new RegisterRequest()
        {
            Email = "emre@posta.mu.edu.tr",
            UserName = "emrecoskun",
            PhoneNumber = "5458413575",
            Password = "P@ssword1!",
            ConfirmPassword = "P@ssword1!",
        };    
        
        // Set up mock behavior
        var failedIdentityResult = IdentityResult.Failed(new IdentityError { Code = "ErrorCode", Description = "ErrorDescription" });
        
        _userManager
            .Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), validRegisterRequest.Password))
            .ReturnsAsync(failedIdentityResult);
        
        // Act
        var result = await authService.Register(validRegisterRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<BadRequestException>());
    }

    #endregion
    
}