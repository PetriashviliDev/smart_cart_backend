using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");
        
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
        
        builder.Property(x => x.Image)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.Property(x => x.Portions)
            .IsRequired();
        
        builder.Property(x => x.Recipe)
            .IsRequired();
        
        builder.Property(x => x.CookingTime)
            .IsRequired();
        
        builder.HasOne(x => x.Difficulty)
            .WithMany()
            .HasForeignKey(x => x.DifficultyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // builder.HasOne(x => x.Category)
        //     .WithMany()
        //     .HasForeignKey(x => x.CategoryId)
        //     .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.DishIngredients)
            .WithOne(x => x.Dish)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}