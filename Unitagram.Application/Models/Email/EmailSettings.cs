namespace Unitagram.Application.Models.Email;

public record EmailSettings()
{
    public string SmtpServer { get; init; } = string.Empty;
    public int SmtpPort { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}