using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Unitagram.Application.Models.Identity;

namespace Unitagram.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    [StringLength(100, ErrorMessage = "Person name can be maximum 100 characters")]
    public string? PersonName { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationDateTime { get; set; }
    
}