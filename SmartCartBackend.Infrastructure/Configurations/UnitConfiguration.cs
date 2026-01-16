using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UnitConfiguration : EnumerationEntityTypeConfiguration<Unit>
{
    public override void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");
        
        base.Configure(builder);
        
        builder.Property(x => x.ShortTitle)
            .HasMaxLength(32)
            .IsRequired();
    }
}