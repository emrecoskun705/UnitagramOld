using Unitagram.Core.DTO;
using Unitagram.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Unitagram.Core.ServiceContracts
{
  public interface IJwtService
  {
    AuthenticationResponse CreateJwtToken(ApplicationUser user);

    ClaimsPrincipal? GetPrincipleFromJwtToken(string? token);
  }
}
