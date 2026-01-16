using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishCategoryConfiguration : EnumerationEntityTypeConfiguration<DishCategory>
{
    public override void Configure(EntityTypeBuilder<DishCategory> builder)
    {
        builder.ToTable("DishCategories");
        
        base.Configure(builder);
        
        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();
        
        builder.Property(x => x.Image)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.HasMany(x => x.Dishes)
            .WithOne(x => x.DishCategory)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}