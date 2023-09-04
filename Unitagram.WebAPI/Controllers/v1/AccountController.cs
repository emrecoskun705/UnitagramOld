using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.WebAPI.Controllers.v1;

/// <summary>
/// Controller responsible for user account-related actions.
/// </summary>
[AllowAnonymous]
[ApiVersion("1.0")]
public class AccountController : CustomControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountController"/> class.
    /// </summary>
    /// <param name="authService">The authentication service to handle user account operations.</param>
    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Processes a login request, authenticating the user and returning an authentication response.
    /// </summary>
    /// <param name="request">The authentication request containing user credentials.</param>
    /// <returns>An <see cref="ActionResult{T}"/> containing an <see cref="AuthResponse"/>.</returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        var result = await _authService.Login(request);
        return result.ToOk(HttpContext);
    }
    
    /// <summary>
    /// Processes a registration request, creating a new user account and returning a registration response.
    /// </summary>
    /// <param name="request">The registration request containing user information.</param>
    /// <returns>An <see cref="ActionResult{T}"/> containing a <see cref="RegisterResponse"/>.</returns>
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
    {
        var result = await _authService.Register(request); 
        return result.ToOk(HttpContext);
    }
    
    /// <summary>
    /// Refreshes an authentication token using a refresh token and returns an updated authentication response.
    /// </summary>
    /// <param name="request">The refresh token request containing a refresh token.</param>
    /// <returns>An <see cref="ActionResult{T}"/> containing an <see cref="AuthResponse"/>.</returns>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthResponse>> RefreshToken(RefreshRequest request)
    {
        throw new ConnectionAbortedException("aborted connection");
        var result = await _authService.RefreshToken(request);
        return result.ToOk(HttpContext);
    }
}