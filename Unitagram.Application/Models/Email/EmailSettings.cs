namespace Unitagram.Application.Models.Email;

public record EmailSettings()
{
    public string SmtpServer { get; init; } = string.Empty;
    public int SmtpPort { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}

// string smtpServer = "smtpout.secureserver.net"; // GoDaddy SMTP server
// int smtpPort = 25; // GoDaddy SMTP port
// string email = "no-reply@unitagram.com";
// string password = "Sogood542!";