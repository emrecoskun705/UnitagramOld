﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Core.DTO;
using Unitagram.Core.Identity;
using Unitagram.Core.ServiceContracts;
using System.Security.Claims;

namespace Unitagram.WebAPI.Controllers.v1
{
  /// <summary>
  /// 
  /// </summary>
  [AllowAnonymous]
  [ApiVersion("1.0")]
  public class AccountController : CustomControllerBase
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtService _jwtService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="signInManager"></param>
    /// <param name="roleManager"></param>
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IJwtService jwtService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
      _jwtService = jwtService;
    }

    /// <summary>
    /// Register user
    /// </summary>
    /// <param name="registerDTO"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<ApplicationUser>> PostRegister(RegisterDTO registerDTO)
    {
      if (ModelState.IsValid == false)
      {
        string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

        return Problem(errorMessage);
      }

      //Create user
      ApplicationUser user = new ApplicationUser()
      {
        Email = registerDTO.Email,
        PhoneNumber = registerDTO.PhoneNumber,
        UserName = registerDTO.Email,
        PersonName = registerDTO.PersonName,
      };

      IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

      if (result.Succeeded)
      {
        //sign-in
        await _signInManager.SignInAsync(user, isPersistent: false);

        var authenticationResponse = _jwtService.CreateJwtToken(user);

        user.RefreshToken = authenticationResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return Ok(authenticationResponse);
      }
      else
      {
        string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description));

        return Problem(errorMessage);
      }

    }

    /// <summary>
    /// Check if email is already registered
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
    {
      ApplicationUser? user = await _userManager.FindByEmailAsync(email);

      if (user == null)
        return Ok(true);

      return Ok(false);
    }

    /// <summary>
    ///  Login user
    /// </summary>
    /// <param name="loginDTO"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> PostLogin(LoginDTO loginDTO)
    {
      //Validation
      if (ModelState.IsValid == false)
      {
        string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

        return Problem(errorMessage);
      }

      var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

      if (result.Succeeded)
      {
        ApplicationUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);

        if (user == null)
          return NoContent();

        var authenticationResponse = _jwtService.CreateJwtToken(user);

        user.RefreshToken = authenticationResponse.RefreshToken;
        user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;
        await _userManager.UpdateAsync(user);

        return Ok(authenticationResponse);
      }
      else
      {
        return Problem("Invalid email or address");
      }

    }

    /// <summary>
    /// Logout user removes token
    /// </summary>
    /// <returns></returns>
    [HttpGet("logout")]
    public async Task<IActionResult> GetLogout()
    {
      await _signInManager.SignOutAsync();

      return NoContent();
    }

    /// <summary>
    /// Generate new access token usin refresh token
    /// </summary>
    /// <param name="tokenModel"></param>
    /// <returns></returns>
    [HttpPost("generate-new-jwt-token")]
    public async Task<IActionResult> GenerateNewAccessToken(TokenModel tokenModel)
    {
      if (tokenModel == null)
        return BadRequest("Invalid client request");


      ClaimsPrincipal? principal = _jwtService.GetPrincipleFromJwtToken(tokenModel.Token);

      if (principal == null)
        return BadRequest("Invalid jwt access token");

      string? email = principal.FindFirstValue(ClaimTypes.Email);

      ApplicationUser? user = await _userManager.FindByEmailAsync(email);

      if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpirationDateTime <= DateTime.Now)
      {
        return BadRequest("Invalid refresh token");
      }

      AuthenticationResponse authenticationResponse = _jwtService.CreateJwtToken(user);

      user.RefreshToken = authenticationResponse.RefreshToken;
      user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;

      await _userManager.UpdateAsync(user);

      return Ok(authenticationResponse);
    }
  }
}
