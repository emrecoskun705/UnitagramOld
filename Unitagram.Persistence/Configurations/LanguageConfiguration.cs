using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Domain;

namespace Unitagram.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Culture)
            .HasMaxLength(5);
        
        builder.Property(u => u.Name)
            .HasMaxLength(30);
    }
}