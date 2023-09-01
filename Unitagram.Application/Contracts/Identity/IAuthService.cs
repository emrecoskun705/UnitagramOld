using Unitagram.Application.Models.Identity;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.Application.Models.Identity.Jwt;
using Unitagram.Application.Models.Identity.Register;

namespace Unitagram.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
    
    Task<AuthResponse> RefreshToken(RefreshRequest request);
}