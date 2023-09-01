using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Domain;

namespace Unitagram.Persistence.Configurations;

public class UniversityConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Province)
            .IsRequired()
            .HasMaxLength(50);
    }
}