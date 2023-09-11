using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unitagram.Domain;

namespace Unitagram.Persistence.Configurations;

public class OtpConfirmationConfiguration : IEntityTypeConfiguration<OtpConfirmation>
{
    public void Configure(EntityTypeBuilder<OtpConfirmation> builder)
    {
        builder.HasKey(o =>  new { o.UserId, o.Name});

        builder.Property(o => o.Name)
            .HasMaxLength(50);

        builder.Property(o => o.RetryCount)
            .HasColumnType("tinyint")
            .HasDefaultValue((byte)0)
            .IsRequired();
        
        builder.Property(o => o.Value)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(o => o.RetryDateTimeUtc)
            .IsRequired(false);
    }
}