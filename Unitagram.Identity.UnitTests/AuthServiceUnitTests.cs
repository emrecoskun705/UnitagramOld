using System.Globalization;
using System.Security.Claims;
using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Serilog;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Contracts.Logging;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;
using Unitagram.Domain;
using Unitagram.Identity.DbContext;
using Unitagram.Identity.Models;
using Unitagram.Identity.Services;

namespace Unitagram.Identity.UnitTests;

public class AuthServiceUnitTests
{
    private readonly Mock<UserManager<ApplicationUser>> _userManager;
    private readonly Mock<SignInManager<ApplicationUser>> _signInManager;
    private readonly Mock<RoleManager<ApplicationRole>> _roleManager;
    private readonly Mock<UnitagramIdentityDbContext> _dbContext;
    private readonly Mock<IJwtService> _jwtService;
    private readonly Mock<IDiagnosticContext> _diagnosticContextMock;
    private readonly Mock<IUniversityRepository> _universityRepositoryMock;
    private readonly Mock<IUniversityUserRepository> _universityUserRepositoryMock;
    private readonly Mock<IEmailVerificationService> _verificationServiceMock;
    private readonly IFixture _fixture;

    private const string ValidJwtTokenWithoutTime =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

    private const string ValidRefreshToken =
        "sj3ms9zKrGIXT1sBiYxSyBa8jt3JRaqGulDDYSCJeDrgswypOUAnoq5caZBTDJh0DSnt/Lla9/N0vC2q+YZJgA==";

    private const string ValidUserName = "emrecoskun";
    
    public AuthServiceUnitTests()
    {
        _fixture = new Fixture();
        // Initialize and set up your mocks here
        _userManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null!, null!, null!,
            null!, null!, null!, null!, null!);

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
            new Mock<RoleManager<ApplicationRole>>(Mock.Of<IRoleStore<ApplicationRole>>(), null!, null!, null!, null!);
        _jwtService = new Mock<IJwtService>();
        _universityRepositoryMock = new Mock<IUniversityRepository>();
        _universityUserRepositoryMock = new Mock<IUniversityUserRepository>();
        _verificationServiceMock = new Mock<IEmailVerificationService>();
        _dbContext = new Mock<UnitagramIdentityDbContext>();
    }
    
    private AuthService CreateAuthService()
    {
        return new AuthService(_userManager.Object, 
            _signInManager.Object, 
            _roleManager.Object,
            _jwtService.Object, 
            _diagnosticContextMock.Object,
            _universityRepositoryMock.Object,
            _universityUserRepositoryMock.Object,
            _dbContext.Object,
            _verificationServiceMock.Object);
    }

    #region Login

    [Fact]
    public async Task Login_ValidCredentials_ReturnsAuthResponse()
    {
        //Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            UserName = "emrecoskun",
            Password = "password123",
        };
        var user = new ApplicationUser { UserName = authRequest.UserName };

        // Set up mock behavior
        _userManager.Setup(u => u.FindByNameAsync(authRequest.UserName)).ReturnsAsync(user);
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
            UserName = "emrecoskun",
            Password = "randomPassword",
        };
        var user = new ApplicationUser { UserName = authRequest.UserName };

        // Set up mock behavior
        _userManager.Setup(u => u.FindByNameAsync(authRequest.UserName)).ReturnsAsync(user);
        _signInManager.Setup(s => s.CheckPasswordSignInAsync(user, authRequest.Password, false))
            .ReturnsAsync(SignInResult.Failed);

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<InvalidAccountCredentialsException>());
    }

    [Fact]
    public async Task Login_InvalidValidation_ReturnsValidationException()
    {
        // Arrange
        var authService = CreateAuthService();
        var authRequest = new AuthRequest
        {
            UserName = "",
            Password = "randomPassword",
        };

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
            UserName = "emre@emre.com",
            Password = "randomPassword",
        };
        // Set up mock behavior
        _userManager.Setup(u => u.FindByEmailAsync(authRequest.UserName)).ReturnsAsync(null as ApplicationUser);

        // Act
        var result = await authService.Login(authRequest);

        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<UserNotFoundException>());
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
        
        _universityRepositoryMock
            .Setup(u => u.GetByDomainAsync(It.IsAny<string>()))
            .ReturnsAsync(_fixture.Build<University>().Create());
        
        var databaseMock = new Mock<DatabaseFacade>(_dbContext.Object);
        var transactionMock = new Mock<IDbContextTransaction>();
        
        _fixture.Inject(_dbContext.Object);
        _dbContext.SetupGet((c => c.Database)).Returns(databaseMock.Object);
        
        databaseMock
            .Setup(d => d.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(transactionMock.Object);
        
        transactionMock.Setup(t => t.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        transactionMock.Setup(t => t.DisposeAsync()).Returns(ValueTask.CompletedTask);
        
        _userManager
            .Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), validRegisterRequest.Password))
            .ReturnsAsync(IdentityResult.Success);
        
        _userManager
            .Setup(u => u.UpdateAsync(It.IsAny<ApplicationUser>()));

        _roleManager
            .Setup(u => u.RoleExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManager
            .Setup(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

        _universityUserRepositoryMock
            .Setup(u => u.CreateAsync(It.IsAny<UniversityUser>()))
            .Returns(Task.CompletedTask);
        
        _jwtService
            .Setup(u => u.CreateJwtToken(It.IsAny<JwtRequest>()));

        // just return some JWT response values for test to work
        _jwtService.Setup(x => x.CreateJwtToken(It.IsAny<JwtRequest>()))
            .Returns(_fixture.Build<JwtResponse>().Create());

        _verificationServiceMock
            .Setup(u => u.GenerateAsync(It.IsAny<Guid>()))
            .ReturnsAsync(Result<Unit>.Bottom);
        

        // Act
        var result = await authService.Register(validRegisterRequest);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IfSucc(registerResponse => registerResponse.Should().NotBeNull());
        result.IfSucc(registerResponse => registerResponse.Should().BeOfType<RegisterResponse>());
    }

    [Theory]
    [InlineData("invalidEmail", "validUsername", "1234567890", "password123", "password123")] // Invalid email
    [InlineData("validemail@example.com", "validUsername", "1234567890", "pass",  "password123")] // Invalid password
    [InlineData("validemail@example.com", "abc", "1234567890", "password123", "password123")] // invalid username
    [InlineData("validemail@example.com", "validUsername", "invalidPhone", "password123", "password123")] // invalid phone
    [InlineData("validemail@example.com", "validUsername", "1234567890", "password123", "password456")] // password do not match
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
        
        _universityRepositoryMock
            .Setup(u => u.GetByDomainAsync(It.IsAny<string>()))
            .ReturnsAsync(_fixture.Build<University>().Create());

        var databaseMock = new Mock<DatabaseFacade>(_dbContext.Object);
        var transactionMock = new Mock<IDbContextTransaction>();
        
        _fixture.Inject(_dbContext.Object);
        _dbContext.SetupGet((c => c.Database)).Returns(databaseMock.Object);
        
        databaseMock.Setup(d => d.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(transactionMock.Object);
        
        _dbContext
            .Setup(u => u.Database.BeginTransactionAsync(default(CancellationToken)))
            .ReturnsAsync(It.IsAny<IDbContextTransaction>());
        
        // Act
        var result = await authService.Register(validRegisterRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<ValidationException>());
    }

    #endregion

    #region RefreshToken

    [Fact]
    public async Task RefreshToken_TokenNull_ReturnsValidationException()
    {
        //Arrange
        var authService = CreateAuthService();
        var refreshRequest = new RefreshRequest()
        {
            Token = string.Empty,
            RefreshToken = string.Empty,
        }; 
        
        // Act
        var result = await authService.RefreshToken(refreshRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<ValidationException>());
    }
    
    [Fact]
    public async Task RefreshToken_UserNameNull_ClaimsPrincipal_ReturnsBadRequestException()
    {
        //Arrange
        var authService = CreateAuthService();
        var refreshRequest = new RefreshRequest()
        {
            Token = ValidJwtTokenWithoutTime,
            RefreshToken = ValidRefreshToken,
        };

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
        }, "your-authentication-type"); 
        var claimsPrincipalWithUserNameNull = new ClaimsPrincipal(identity);

        _jwtService.Setup(p => p.GetPrincipleFromJwtToken(refreshRequest.Token))
            .Returns(claimsPrincipalWithUserNameNull);
        
        // Act
        var result = await authService.RefreshToken(refreshRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<JwtTokenException>());
    }
    
    [Fact]
    public async Task RefreshToken_UserNull_ReturnsNotFoundException()
    {
        //Arrange
        var authService = CreateAuthService();
        var refreshRequest = new RefreshRequest()
        {
            Token = ValidJwtTokenWithoutTime,
            RefreshToken = ValidRefreshToken,
        };

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, ValidUserName)
        }, "your-authentication-type");
        var claimsPrincipalValid = new ClaimsPrincipal(identity);
        
        // Mock
        _jwtService.Setup(p => p.GetPrincipleFromJwtToken(refreshRequest.Token))
            .Returns(claimsPrincipalValid);

        _userManager.Setup(p => p.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(null as ApplicationUser);
        
        // Act
        var result = await authService.RefreshToken(refreshRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<UserNotFoundException>());
    }
    
    [Fact]
    public async Task RefreshToken_InvalidRefreshToken_ReturnsBadException()
    {
        //Arrange
        var authService = CreateAuthService();
        var refreshRequest = new RefreshRequest()
        {
            Token = ValidJwtTokenWithoutTime,
            RefreshToken = ValidRefreshToken,
        };

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, ValidUserName)
        }, "your-authentication-type"); 
        var claimsPrincipalValid = new ClaimsPrincipal(identity);

        var applicationUserRefreshTokenNotEqual = _fixture
            .Build<ApplicationUser>()
            .With(p => p.RefreshToken, "notSameRefreshTokenWithValidRefreshToken")
            .With(p => p.RefreshTokenExpirationDateTime, DateTime.Now)
            .Create();
        
        // Mock
        _jwtService.Setup(p => p.GetPrincipleFromJwtToken(refreshRequest.Token))
            .Returns(claimsPrincipalValid);

        _userManager.Setup(p => p.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(applicationUserRefreshTokenNotEqual);
        
        // Act
        var result = await authService.RefreshToken(refreshRequest);
        
        // Assert
        result.IsFaulted.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<JwtTokenException>());
        result.IfFail(e => e.Message.Should().Be("Invalid refresh token"));
    }
    
    [Fact]
    public async Task RefreshToken_ValidRefreshRequest_ReturnsAuthResponse()
    {
        //Arrange
        var authService = CreateAuthService();
        var refreshRequest = new RefreshRequest()
        {
            Token = ValidJwtTokenWithoutTime,
            RefreshToken = ValidRefreshToken,
        };

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, ValidUserName)
        }, "your-authentication-type"); 
        var claimsPrincipalValid = new ClaimsPrincipal(identity);

        var applicationUserRefreshTokenNotEqual = _fixture
            .Build<ApplicationUser>()
            .With(p => p.RefreshToken, refreshRequest.RefreshToken)
            .With(p => p.RefreshTokenExpirationDateTime, DateTime.Now.AddDays(2))
            .Create();
        
        // Mock
        _jwtService.Setup(p => p.GetPrincipleFromJwtToken(refreshRequest.Token))
            .Returns(claimsPrincipalValid);

        _userManager.Setup(p => p.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(applicationUserRefreshTokenNotEqual);

        _jwtService.Setup(p => p.CreateJwtToken(It.IsAny<JwtRequest>()))
            .Returns(_fixture.Build<JwtResponse>().Create());

        _userManager.Setup(p => p.UpdateAsync(It.IsAny<ApplicationUser>()));
        
        // Act
        var result = await authService.RefreshToken(refreshRequest);
        
        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IfFail(e => e.Should().BeOfType<JwtResponse>());
    }

    #endregion
    
}