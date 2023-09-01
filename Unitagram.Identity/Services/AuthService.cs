using System.Security.Claims;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Serilog;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly IDiagnosticContext _diagnosticContext;
    public AuthService(UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        RoleManager<ApplicationRole> roleManager, 
        IJwtService jwtService, 
        ILogger<AuthService> logger, 
        IDiagnosticContext diagnosticContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _diagnosticContext = diagnosticContext;
    }

    public async Task<Result<AuthResponse>> Login(AuthRequest request)
    {
        var validator = new AuthRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any()) {
            var validationException = new ValidationException(validationResult);
            return new Result<AuthResponse>(validationException);
        }
        
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            var notFoundException = new NotFoundException("User", request.Email);
            return new Result<AuthResponse>(notFoundException); 
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            var badRequestException = new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            return new Result<AuthResponse>(badRequestException);  
        }
        
        JwtResponse jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));
        // update user
        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return jwtResponse.ToAuthResponse();
    }

    public async Task<Result<RegisterResponse>> Register(RegisterRequest request)
    {
        var validator = new RegisterRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
        {
            var exception = new ValidationException(validationResult);
            return new Result<RegisterResponse>(exception);
        }
        
        //Create user
        ApplicationUser user = new ApplicationUser()
        {
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        
        if (!result.Succeeded)
        {
            string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description));
            var exception =  new BadRequestException(errorMessage);
            return new Result<RegisterResponse>(exception);
        }
        
        _diagnosticContext.Set("CreatedUser", user.UserName);
        
        JwtResponse jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));

        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return jwtResponse.ToRegisterResponse();
    }

    public async Task<Result<AuthResponse>> RefreshToken(RefreshRequest request)
    {
        if (request == null)
        {
            var exception = new BadRequestException("Invalid client request");
            return new Result<AuthResponse>(exception);
        }
        
        ClaimsPrincipal? principal = _jwtService.GetPrincipleFromJwtToken(request.Token);
        
        if (principal == null)
            throw  new BadRequestException("Invalid access token");
        
        string? email = principal.FindFirstValue(ClaimTypes.Email);
        ApplicationUser? user = await _userManager.FindByEmailAsync(email);
        
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpirationDateTime <= DateTime.Now)
        {
            var exception = new BadRequestException("Invalid refresh token");
            return new Result<AuthResponse>(exception);
        }
        
        var jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));
        
        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;

        await _userManager.UpdateAsync(user);
        
        return jwtResponse.ToAuthResponse();
    }

    private async Task<JwtRequest> UserToJwtRequest(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var jwtRequest = new JwtRequest()
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Roles = roles,
        };

        return jwtRequest;
    }
}