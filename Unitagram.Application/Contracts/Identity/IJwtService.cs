using System.Security.Claims;
using Unitagram.Application.Models.Identity;
using Unitagram.Application.Models.Identity.Jwt;

namespace Unitagram.Application.Contracts.Identity;

public interface IJwtService
{
    JwtResponse CreateJwtToken(JwtRequest user);

    ClaimsPrincipal GetPrincipleFromJwtToken(string? token);
}