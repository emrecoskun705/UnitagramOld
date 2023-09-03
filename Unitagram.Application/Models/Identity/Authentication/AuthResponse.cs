namespace Unitagram.Application.Models.Identity.Authentication;

public record AuthResponse
{
    public string UserName { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}