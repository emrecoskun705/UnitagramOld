using System.Security.Claims;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Serilog;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;
using Unitagram.Domain;
using Unitagram.Identity.DbContext;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly IDiagnosticContext _diagnosticContext;
    private readonly IUniversityRepository _universityRepository;
    private readonly IUniversityUserRepository _universityUserRepository;
    private readonly UnitagramIdentityDbContext _databaseContext;

    public AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager,
        IJwtService jwtService,
        IDiagnosticContext diagnosticContext,
        IUniversityRepository universityRepository,
        IUniversityUserRepository universityUserRepository,
        UnitagramIdentityDbContext databaseContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _diagnosticContext = diagnosticContext;
        _universityRepository = universityRepository;
        _universityUserRepository = universityUserRepository;
        _databaseContext = databaseContext;
    }

    public async Task<Result<AuthResponse>> Login(AuthRequest request)
    {
        var validator = new AuthRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            var validationException = new ValidationException(validationResult);
            return new Result<AuthResponse>(validationException);
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            var notFoundException = new NotFoundException("User", request.UserName);
            return new Result<AuthResponse>(notFoundException);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            var badRequestException = new BadRequestException($"Credentials for '{request.UserName} aren't valid'.");
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

        var getEmailDomain = GetEmailDomain(request);

        var getUniversity = await _universityRepository.GetByDomainAsync(getEmailDomain);
        if (getUniversity is null)
        {
            var exception = new NotFoundException("University", getEmailDomain);
            return new Result<RegisterResponse>(exception);
        }

        await using var transaction = await _databaseContext.Database.BeginTransactionAsync();

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
            string errorMessage = string.Join("|", result.Errors.Select(e => e.Description));
            var exception = new BadRequestException(errorMessage);
            return new Result<RegisterResponse>(exception);
        }

        // Add the user to the "UniversityUser" role
        await AddRoleToUserAsync(user, "UniversityUser");

        try
        {
            await _universityUserRepository.CreateAsync(new UniversityUser()
            {
                UserId = user.Id,
                UniversityId = getUniversity.UniversityId,
            });
            // Commit the transaction since both operations were successful
            await transaction.CommitAsync();
            await transaction.DisposeAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }

        JwtResponse jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));

        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);


        _diagnosticContext.Set("CreatedUser", user.UserName);
        _diagnosticContext.Set("University", getUniversity.Name);

        return jwtResponse.ToRegisterResponse();
    }

    private static string GetEmailDomain(RegisterRequest request)
    {
        return request.Email.Split('@')[1];
    }

    public async Task<Result<AuthResponse>> RefreshToken(RefreshRequest request)
    {
        var validator = new RefreshRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            var exception = new ValidationException(validationResult);
            return new Result<AuthResponse>(exception);
        }

        ClaimsPrincipal principal = _jwtService.GetPrincipleFromJwtToken(request.Token);

        // if (principal == null) // This should never happen if it throws that exception, catch it from exception middleware and log it
        //     throw new BadRequestException("Invalid access token");
        string? username = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (username == null)
        {
            var exception = new BadRequestException("Invalid access token");
            return new Result<AuthResponse>(exception);
        }

        ApplicationUser? user = await _userManager.FindByNameAsync(username);

        if (user is null)
        {
            var exception = new NotFoundException("User", username);
            return new Result<AuthResponse>(exception);
        }

        bool isValidRefreshToken = user.RefreshToken != request.RefreshToken ||
                                   user.RefreshTokenExpirationDateTime <= DateTime.Now;
        if (isValidRefreshToken)
        {
            var exception = new BadRequestException("Invalid refresh token");
            return new Result<AuthResponse>(exception);
        }

        var jwtResponse = _jwtService.CreateJwtToken(await UserToJwtRequest(user));
        // Update Refresh Token for user in DB
        user.RefreshToken = jwtResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;

        await _userManager.UpdateAsync(user);

        return jwtResponse.ToAuthResponse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ApplicationException"></exception>
    private async Task AddRoleToUserAsync(ApplicationUser user, string roleName)
    {
        // Check if the user is null
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        // Check if the role name is null or empty
        if (string.IsNullOrWhiteSpace(roleName))
        {
            throw new ArgumentException("Role name cannot be null or empty.", nameof(roleName));
        }

        // Check if the role exists
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            throw new InvalidOperationException($"Role '{roleName}' does not exist.");
        }

        // Add the user to the role
        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            // Role assignment failed, throw an exception
            throw new ApplicationException($"Failed to assign role '{roleName}' to the user.");
        }
    }

    private async Task<JwtRequest> UserToJwtRequest(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var jwtRequest = new JwtRequest()
        {
            Id = user.Id,
            UserName = user.UserName!,
            Roles = roles,
        };

        return jwtRequest;
    }
}