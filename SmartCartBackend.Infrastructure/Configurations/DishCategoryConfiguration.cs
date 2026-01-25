using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishCategoryConfiguration : DisplayEnumerationEntityTypeConfiguration<DishCategory>
{
    public override void Configure(EntityTypeBuilder<DishCategory> builder)
    {
        builder.ToTable("DishCategories");
        
        base.Configure(builder);
        
        builder.HasMany(x => x.Dishes)
            .WithOne(x => x.DishCategory)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}