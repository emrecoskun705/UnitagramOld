using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
        public DbSet<UniversityDomain> UniversityDomain { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UniversityDomain>()
                .HasOne(d => d.University)
                .WithMany(u => u.UniversityDomains)
                .HasForeignKey(d => d.UniversityId)
                .IsRequired();


            base.OnModelCreating(builder);
        }


    }
}
