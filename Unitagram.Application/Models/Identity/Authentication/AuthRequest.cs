namespace Unitagram.Application.Models.Identity.Authentication;

public record AuthRequest
{
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}