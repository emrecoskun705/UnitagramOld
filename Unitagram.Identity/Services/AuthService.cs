using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        RoleManager<ApplicationRole> roleManager, 
        IJwtService jwtService,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with {request.Email} not found.", request.Email);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
        }
        
        JwtResponse jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));
        // update user
        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return jwtResponse.ToAuthResponse();
    }

    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
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
            throw new BadRequestException(errorMessage);
        }
        
        var roles = await _userManager.GetRolesAsync(user);
        
        JwtResponse jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));

        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return jwtResponse.ToRegisterResponse();
    }

    public async Task<AuthResponse> RefreshToken(RefreshRequest request)
    {
        if (request == null)
            throw  new BadRequestException("Invalid client request");
        
        ClaimsPrincipal? principal = _jwtService.GetPrincipleFromJwtToken(request.Token);
        
        if (principal == null)
            throw  new BadRequestException("Invalid access token");
        
        string? email = principal.FindFirstValue(ClaimTypes.Email);
        ApplicationUser? user = await _userManager.FindByEmailAsync(email);
        
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpirationDateTime <= DateTime.Now)
        {
            throw  new BadRequestException("Invalid refresh token");
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