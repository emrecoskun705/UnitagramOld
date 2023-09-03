namespace Unitagram.Application.Models.Identity.Register;

public record RegisterResponse
{
    public string UserName { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}