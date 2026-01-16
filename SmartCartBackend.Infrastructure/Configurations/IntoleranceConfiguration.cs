using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class IntoleranceConfiguration : EnumerationEntityTypeConfiguration<Intolerance>
{
    public override void Configure(EntityTypeBuilder<Intolerance> builder)
    {
        builder.ToTable("Intolerances");
        
        base.Configure(builder);
    }
}