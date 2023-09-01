using Unitagram.Application.Models.Identity;

namespace Unitagram.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
    
    Task<AuthResponse> RefreshToken(RefreshRequest request);
}