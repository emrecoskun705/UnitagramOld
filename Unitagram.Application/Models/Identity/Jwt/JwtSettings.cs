namespace Unitagram.Application.Models.Identity.Jwt;

public record JwtSettings
{
    public string Key { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public int ExpirationDays { get; init; }
    public int RefreshTokenValidityInDays { get; init; }
}