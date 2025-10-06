using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class MealsConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();

        builder.Property(x => x.Date)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
        
        builder.HasOne(x => x.MealType)
            .WithMany()
            .HasForeignKey(x => x.MealTypeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.MealPlan)
            .WithMany(x => x.Meals)
            .HasForeignKey(x => x.MealPlanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(x => x.Date);
        builder.HasIndex(x => new { x.MealPlanId, x.Date });
    }
}