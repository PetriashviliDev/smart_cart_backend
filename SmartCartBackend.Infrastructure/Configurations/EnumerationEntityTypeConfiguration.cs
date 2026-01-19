using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCartBackend.Infrastructure.Configurations;

public class EnumerationEntityTypeConfiguration<TEnumeration> 
    : IEntityTypeConfiguration<TEnumeration>
    where TEnumeration : Enumeration
{
    public virtual void Configure(EntityTypeBuilder<TEnumeration> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.InternalName)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.IsAdded)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InternalName)
            .IsUnique();
    }
}