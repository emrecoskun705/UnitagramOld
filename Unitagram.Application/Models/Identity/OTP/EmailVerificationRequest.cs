namespace Unitagram.Application.Models.Identity.OTP;

public record EmailVerificationRequest
{
    public string UserName { get; init; } = string.Empty;
    public string EmailToken { get; init; } = string.Empty;
}