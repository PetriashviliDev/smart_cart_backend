using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishIngredientConfiguration : IEntityTypeConfiguration<DishIngredient>
{
    public void Configure(EntityTypeBuilder<DishIngredient> builder)
    {
        builder.ToTable("DishIngredients");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.Amount)
            .IsRequired();
        
        builder.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Dish)
            .WithMany(x => x.DishIngredients)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(x => x.Ingredient)
            .WithMany(x => x.DishIngredients)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(x => new { x.DishId, x.IngredientId })
            .IsUnique();
    }
}