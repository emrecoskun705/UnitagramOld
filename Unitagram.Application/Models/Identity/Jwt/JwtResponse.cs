using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.Application.Models.Identity.Jwt;

public class JwtResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public DateTime RefreshTokenExpirationDateTime { get; set; }

    public AuthResponse ToAuthResponse()
    {
        return new()
        {
            Id = Id,
            UserName = UserName,
            Token = Token,
            RefreshToken = RefreshToken,
        };
    }

    public RegisterResponse ToRegisterResponse()
    {
        return new()
        {
            Id = Id,
            UserName = UserName,
            Token = Token,
            RefreshToken = RefreshToken,
        };
    }
}