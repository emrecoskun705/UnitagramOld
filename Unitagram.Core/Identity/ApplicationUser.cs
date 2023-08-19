using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitagram.Core.Identity
{
  public class ApplicationUser : IdentityUser<Guid>
  {
    [StringLength(100, ErrorMessage = "Person name can be maximum 100 characters")]
    public string? PersonName { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationDateTime { get; set; }
  }
}
