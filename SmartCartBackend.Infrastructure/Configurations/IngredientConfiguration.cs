using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class IngredientConfiguration : DisplayEnumerationEntityTypeConfiguration<Ingredient>
{
    public override void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");
        
        base.Configure(builder);
        
        builder.Property(x => x.Calories)
            .IsRequired();
        
        builder.Property(x => x.Proteins)
            .IsRequired();
        
        builder.Property(x => x.Fats)
            .IsRequired();
        
        builder.Property(x => x.Carbohydrates)
            .IsRequired();
        
        builder.Property(x => x.CategoryId)
            .IsRequired();
        
        builder.HasMany(x => x.DishIngredients)
            .WithOne(x => x.Ingredient)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}