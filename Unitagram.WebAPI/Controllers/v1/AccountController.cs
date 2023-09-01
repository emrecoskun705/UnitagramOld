using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Models.Identity;

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
    [HttpPost]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authService.Login(request));
    }
    
    /// <summary>
    /// Register Request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
    {
        return Ok(await _authService.Register(request));
    }
    
    /// <summary>
    /// Refresh Token test
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<RegisterResponse>> RefreshToken(RefreshRequest request)
    {
        return Ok(await _authService.RefreshToken(request));
    }
}