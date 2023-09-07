using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Domain;

namespace Unitagram.Persistence.Configurations;

public class UniversityUserConfiguration : IEntityTypeConfiguration<UniversityUser>
{
    public void Configure(EntityTypeBuilder<UniversityUser> builder)
    {
        // Primary Key
        builder.HasKey(u => u.UserId);
        
        //Indexes
        builder.HasIndex(u => u.UniversityId)
            .HasDatabaseName("IX_UniversityUser_UniversityId");
        
        builder.Property(u => u.UserId)
            .IsRequired();

    }
}