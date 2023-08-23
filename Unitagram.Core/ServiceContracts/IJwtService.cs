using Unitagram.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Unitagram.Core.Domain.Identity;

namespace Unitagram.Core.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user);

        ClaimsPrincipal? GetPrincipleFromJwtToken(string? token);
    }
}
