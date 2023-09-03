namespace Unitagram.Application.Models.Identity.Jwt;

public record JwtRequest
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public IList<string> Roles { get; init; } = new List<string>();
}