using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishConfiguration : DisplayEnumerationEntityTypeConfiguration<Dish>
{
    public override void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");
        
        base.Configure(builder);
        
        builder.Property(x => x.Portions)
            .IsRequired();
        
        builder.Property(x => x.Recipe)
            .IsRequired();
        
        builder.Property(x => x.CookingTime)
            .IsRequired();

        builder.Property(x => x.DifficultyId)
            .IsRequired();

        builder.Property(x => x.MealTypeId)
            .IsRequired();
        
        builder.HasOne(x => x.Difficulty)
            .WithMany()
            .HasForeignKey(x => x.DifficultyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.DishIngredients)
            .WithOne(x => x.Dish)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.DishEmbedding)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.MealType)
            .WithMany()
            .HasForeignKey(x => x.MealTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}