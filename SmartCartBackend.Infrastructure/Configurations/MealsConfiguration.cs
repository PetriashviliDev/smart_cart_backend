using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class MealsConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Date)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.HasOne(x => x.MealType)
            .WithMany()
            .HasForeignKey(x => x.MealTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.MealPlan)
            .WithMany(x => x.Meals)
            .HasForeignKey(x => x.MealPlanId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(x => x.Date);
        builder.HasIndex(x => new { x.MealPlanId, x.Date });
    }
}