namespace Unitagram.Application.Models.Identity.OTP;

public record EmailOtpSettings
{
    public string Name { get; init; } = string.Empty;
    public int RetryCount { get; init; }
}