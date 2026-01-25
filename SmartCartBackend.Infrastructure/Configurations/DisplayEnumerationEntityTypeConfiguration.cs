using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DisplayEnumerationEntityTypeConfiguration<TEnumeration> 
    : EnumerationEntityTypeConfiguration<TEnumeration>
    where TEnumeration : DisplayEnumeration
{
    public override void Configure(EntityTypeBuilder<TEnumeration> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();
        
        builder.Property(x => x.Image)
            .HasMaxLength(128)
            .IsRequired();
    }
}