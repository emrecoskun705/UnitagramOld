using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser
            {
                Id = Guid.Parse("DBDD8D97-1685-4383-80A0-39D4C3BB7E08"),
                Email = "admin@unitagram.com",
                PersonName = "System",
                UserName = "admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            }
        );
    }
}