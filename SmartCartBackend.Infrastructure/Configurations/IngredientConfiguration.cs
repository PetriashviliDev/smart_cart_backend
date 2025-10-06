using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");
        
        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();

        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();
        
        builder.Property(x => x.Calories)
            .IsRequired();
        
        builder.Property(x => x.Proteins)
            .IsRequired();
        
        builder.Property(x => x.Fats)
            .IsRequired();
        
        builder.Property(x => x.Carbohydrates)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.HasMany(x => x.DishIngredients)
            .WithOne(x => x.Ingredient)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}