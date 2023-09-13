using LanguageExt.Common;
using Unitagram.Application.Models.Identity;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.OTP;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.Application.Contracts.Identity;

public interface IAuthService
{
    Task<Result<AuthResponse>> Login(AuthRequest request);
    Task<Result<RegisterResponse>> Register(RegisterRequest request);
    Task<Result<EmailVerificationResponse>> ConfirmEmail(EmailVerificationRequest request);
    Task<Result<GenerateOtpResponse>> GenerateOtpEmail(GenerateOtpRequest request);
    
    Task<Result<AuthResponse>> RefreshToken(RefreshRequest request);
}