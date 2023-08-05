using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unitagram.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Unitagram.Infrastructure.DatabaseContext
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }


  }
}
