using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Core.DTO;
using Unitagram.Core.ServiceContracts;
using System.Security.Claims;
using Serilog;
using Unitagram.Core.Domain.Identity;

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
        private readonly ILogger<AccountController> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="jwtService"></param>
        /// <param name="logger"></param>
        /// <param name="diagnosticContext"></param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IJwtService jwtService, ILogger<AccountController> logger, IDiagnosticContext diagnosticContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }

        /// <summary>
        /// This method handles user registration. It validates the provided registration data, creates a new user with the provided details, and attempts to create 
        /// the user using the UserManager. If successful, the user is signed in, a JWT token is generated, and the response includes the authentication details. 
        /// If registration fails, an error message is returned.
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
                UserName = registerDTO.UserName,
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

                _diagnosticContext.Set("CreatedUser", authenticationResponse);

                return Ok(authenticationResponse);
            }
            else
            {
                string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description));

                return Problem(errorMessage, statusCode: 400);
            }

        }

        /// <summary>
        /// This method checks if an email address is already registered in the system. It uses the UserManager to find a user with the given email. 
        /// If the user is found, the response indicates that the email is already registered; otherwise, it's considered available.
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
        ///  This method handles user login. It validates the provided login data and attempts to sign in the user using the SignInManager. If login is successful, 
        ///  a JWT token is generated, and the response includes the authentication details. If login fails, an error message is returned.
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
            
            ApplicationUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
                return Problem("Invalid email or password", statusCode: 400);

            var result = await _signInManager.PasswordSignInAsync(user.UserName!, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var authenticationResponse = _jwtService.CreateJwtToken(user);

                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;
                await _userManager.UpdateAsync(user);

                return Ok(authenticationResponse);
            }
            else
            {
                return Problem("Invalid email or password", statusCode: 400);
            }

        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet("logout")]
        public async Task<IActionResult> GetLogout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }

        /// <summary>
        /// Generates a new access token using a refresh token.
        /// </summary>
        /// <param name="tokenModel">The token model containing the refresh token.</param>
        /// <returns>Returns a new access token if the request is valid; otherwise, returns a BadRequest result.</returns>
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
