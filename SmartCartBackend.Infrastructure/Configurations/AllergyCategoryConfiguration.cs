using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class AllergyCategoryConfiguration : EnumerationEntityTypeConfiguration<AllergyCategory>
{
    public override void Configure(EntityTypeBuilder<AllergyCategory> builder)
    {
        builder.ToTable("AllergyCategories");
        
        base.Configure(builder);
    }
}