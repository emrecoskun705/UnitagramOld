using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Unitagram.Application.Models.Identity.Jwt;

namespace Unitagram.WebAPI.CustomFilters;

/// <summary>
/// Authorization filter for checking email confirmation status.
/// </summary>
public class EmailConfirmationFilter : IAuthorizationFilter
{
    /// <summary>
    /// Checks if the user's email is confirmed before granting access to a resource.
    /// </summary>
    /// <param name="context">The authorization filter context.</param>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthenticated = context.HttpContext?.User?.Identity?.IsAuthenticated;

        if (isAuthenticated is not null && isAuthenticated.Value)
        {
            var emailVerifiedClaim = context.HttpContext?.User?.FindFirst(JwtCustomClaimNames.EmailVerified);
            if (emailVerifiedClaim != null && bool.TryParse(emailVerifiedClaim.Value, out var emailVerified) && !emailVerified)
            {
                // User's email is not verified; you can return a forbidden response or handle it as needed.
                var request = context.HttpContext?.Request;
                var requestUrl = $"{request?.Path}{request?.QueryString}";
                
                var problemDetails = new ProblemDetails()
                {
                    Status = StatusCodes.Status403Forbidden,
                    Type = "EmailNotConfirmed",
                    Detail = "Email is not confirmed please, confirm your email",
                    Instance = requestUrl
                };
                context.Result = new ObjectResult(problemDetails);
            }
        }
    }
}