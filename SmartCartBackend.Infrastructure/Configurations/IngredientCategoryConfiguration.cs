using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class IngredientCategoryConfiguration : DisplayEnumerationEntityTypeConfiguration<IngredientCategory>
{
    public override void Configure(EntityTypeBuilder<IngredientCategory> builder)
    {
        builder.ToTable("IngredientCategories");
        
        base.Configure(builder);
    }
}