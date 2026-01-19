using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class CookingTimeConfiguration : EnumerationEntityTypeConfiguration<CookingTime>
{
    public override void Configure(EntityTypeBuilder<CookingTime> builder)
    {
        builder.ToTable("CookingTime");
        
        base.Configure(builder);

        builder
            .Property(x => x.Limit)
            .IsRequired(false);
    }
}