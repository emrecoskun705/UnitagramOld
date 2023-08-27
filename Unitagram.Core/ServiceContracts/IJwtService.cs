using Unitagram.Core.DTO;
using System.Security.Claims;
using Unitagram.Core.Domain.Identity;

namespace Unitagram.Core.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user);

        ClaimsPrincipal? GetPrincipleFromJwtToken(string? token);
    }
}
