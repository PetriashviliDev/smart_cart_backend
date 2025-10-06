using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class PhoneVerificationConfiguration : IEntityTypeConfiguration<PhoneVerification>
{
    public void Configure(EntityTypeBuilder<PhoneVerification> builder)
    {
        builder.ToTable("PhoneVerifications");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();

        builder.Property(x => x.Phone)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(x => x.Code)
            .HasMaxLength(6)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
        
        builder.Property(x => x.ExpiresAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
        
        builder.Property(x => x.IsConfirmed)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.ConfirmedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);

        builder.HasIndex(x => x.Phone);
    }
}