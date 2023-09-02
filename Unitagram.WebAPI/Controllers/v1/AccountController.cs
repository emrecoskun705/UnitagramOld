using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.WebAPI.Controllers.v1;

/// <summary>
/// 
/// </summary>
[AllowAnonymous]
[ApiVersion("1.0")]
public class AccountController : CustomControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authService"></param>
    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Login Test
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        var result = await _authService.Login(request);
        return result.ToOk(HttpContext);
    }
    
    /// <summary>
    /// Register Request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
    {
        var result = await _authService.Register(request); 
        return result.ToOk(HttpContext);
    }
    
    /// <summary>
    /// Refresh Token test
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthResponse>> RefreshToken(RefreshRequest request)
    {
        var result = await _authService.RefreshToken(request);
        return result.ToOk(HttpContext);
    }
}