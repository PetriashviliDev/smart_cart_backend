using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.Phone)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(x => x.Gender)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(x => x.Age)
            .IsRequired();
        
        builder.Property(x => x.Height)
            .HasPrecision(10, 1)
            .IsRequired();
        
        builder.Property(x => x.Weight)
            .HasPrecision(10, 1)
            .IsRequired();
        
        builder.Property(x => x.RefreshTokenHash)
            .IsRequired();
        
        builder.Property(x => x.RefreshTokenExpiry)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.ExcludedProducts)
            .HasMaxLength(512)
            .IsRequired(false);
        
        builder.Property(x => x.ActivityLevelId)
            .IsRequired();
        
        builder.HasMany(x => x.Preferences)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.Allergies)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.ActivityLevel)
            .WithMany()
            .HasForeignKey(x => x.ActivityLevelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Phone)
            .IsUnique();
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.Navigation(x => x.Preferences)
            .AutoInclude();
        
        builder.Navigation(x => x.Allergies)
            .AutoInclude();
    }
}