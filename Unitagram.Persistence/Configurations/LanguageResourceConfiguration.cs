using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Domain;

namespace Unitagram.Persistence.Configurations;

public class LanguageResourceConfiguration : IEntityTypeConfiguration<LanguageResource>
{
    public void Configure(EntityTypeBuilder<LanguageResource> builder)
    {
        builder.HasKey(u => new {u.Id, u.Source, u.SourceKey});

        builder.Property(u => u.Source)
            .HasMaxLength(20);
        
        builder.Property(u => u.SourceKey)
            .HasMaxLength(50);
        
        builder.Property(u => u.ModifiedBy)
            .HasMaxLength(15);
        
        builder.Property(u => u.CreatedBy)
            .HasMaxLength(15);
        
       builder
            .HasOne(lr => lr.Language)
            .WithMany(l => l.LanguageResources)
            .HasForeignKey(lr => lr.LanguageId);
    }
}