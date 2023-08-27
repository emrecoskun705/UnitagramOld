using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unitagram.Core.Domain.Entities;
using Unitagram.Core.Domain.Identity;

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

        public DbSet<University> University { get; set; }
        public DbSet<UniversityDomain> UniversityDomains { get; set; }
        public DbSet<Domain> Domain { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domain>()
                .HasIndex(d => d.Name)
            .IsUnique();


            builder.Entity<UniversityDomain>()
            .HasKey(ud => new { ud.UniversityId, ud.DomainId });


            base.OnModelCreating(builder);
        }


    }
}
