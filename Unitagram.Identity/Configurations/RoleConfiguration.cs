using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(
            new ApplicationRole()
            {
                Id = Guid.Parse("8426249A-A917-45E8-B8BB-43A551A884ED"),
                Name = "UniversityUser",
                NormalizedName = "UNIVERSITYUSER"
            },
            new ApplicationRole
            {
                Id = Guid.Parse("CD7EB224-B08C-46CA-876A-5BB99EF4AD13"),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}