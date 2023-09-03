namespace Unitagram.Application.Models.Identity.Jwt;

public record RefreshRequest
{
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}