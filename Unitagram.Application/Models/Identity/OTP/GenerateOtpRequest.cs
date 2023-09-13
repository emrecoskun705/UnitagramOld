namespace Unitagram.Application.Models.Identity.OTP;

public record GenerateOtpRequest
{
    public string JwtToken { get; init; } = string.Empty;
}