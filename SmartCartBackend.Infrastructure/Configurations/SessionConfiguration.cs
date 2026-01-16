using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Phone)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(x => x.IpAddress)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(x => x.UserAgent)
            .HasMaxLength(1024)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.ExpiresAt)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.IsUsed)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.UsedAt)
            .HasNullableDateTimeOffsetConversion()
            .IsRequired(false);

        builder.HasIndex(x => x.Phone);
    }
}