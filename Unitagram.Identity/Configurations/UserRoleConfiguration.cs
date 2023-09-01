using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unitagram.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("CD7EB224-B08C-46CA-876A-5BB99EF4AD13"),
                UserId = Guid.Parse("DBDD8D97-1685-4383-80A0-39D4C3BB7E08")
            }
        );
    }
}