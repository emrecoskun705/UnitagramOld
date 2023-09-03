using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Models.Identity;
using Unitagram.Application.Models.Identity.Jwt;

namespace Unitagram.Identity.Services;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public JwtResponse CreateJwtToken(JwtRequest user)
    {
        var roleClaims = user.Roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

        DateTime expiration = DateTime.UtcNow.AddDays(Convert.ToDouble(_jwtSettings.ExpirationDays));

        // Create an array of Claim objects representing the user's claims, such as their ID, name, email, etc.
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName), //Subject (user id)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JWT unique ID
            new Claim(JwtRegisteredClaimNames.Iat,
                DateTime.UtcNow.ToString()), //Issued at (date and time of token generation)
        }
        // .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expiration,
            signingCredentials: signingCredentials
        );
        
        // Create a JwtSecurityTokenHandler object and use it to write the token as a string.
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string token = tokenHandler.WriteToken(tokenGenerator);

        // Create and return an AuthenticationResponse object containing the token, user email, user name, and token expiration time.
        return new JwtResponse()
        {
            Token = token,
            UserName = user.UserName,
            Expiration = expiration,
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpirationDateTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenValidityInDays)
        };
    }

    public ClaimsPrincipal GetPrincipleFromJwtToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidAudience = _jwtSettings.Audience,
            ValidateIssuer = true,
            ValidIssuer = _jwtSettings.Issuer,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),

            ValidateLifetime = false, //should be false
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        ClaimsPrincipal principal =
            jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    //Creates a refresh token (base 64 string of random numbers)
    private string GenerateRefreshToken()
    {
        Byte[] bytes = new Byte[64];
        var randomNumberGen = RandomNumberGenerator.Create();
        randomNumberGen.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}