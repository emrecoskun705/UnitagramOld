using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.Application.Models.Identity.Jwt;

public record JwtResponse
{
    public string UserName { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public DateTime Expiration { get; init; }
    public DateTime RefreshTokenExpirationDateTime { get; init; }

    public AuthResponse ToAuthResponse()
    {
        return new()
        {
            UserName = UserName,
            Token = Token,
            RefreshToken = RefreshToken,
        };
    }

    public RegisterResponse ToRegisterResponse()
    {
        return new()
        {
            UserName = UserName,
            Token = Token,
            RefreshToken = RefreshToken,
        };
    }
}