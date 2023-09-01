using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.DbContext;

public class UnitagramIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public UnitagramIdentityDbContext(DbContextOptions<UnitagramIdentityDbContext> options)
        : base(options)
    {
    }

    protected UnitagramIdentityDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(UnitagramIdentityDbContext).Assembly);
    }
}