using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCartBackend.Infrastructure.Configurations;

public class NutritionPlanChoiceConfiguration : IEntityTypeConfiguration<NutritionPlanChoice>
{
    public void Configure(EntityTypeBuilder<NutritionPlanChoice> builder)
    {
        builder.ToTable("NutritionPlanChoices");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.PlanId)
            .IsRequired();
        
        builder.Property(x => x.DayNumber)
            .IsRequired();
        
        builder.Property(x => x.DishId)
            .IsRequired();
        
        builder.Property(x => x.Choice)
            .HasConversion(new EnumToStringConverter<DishChoice>())
            .IsRequired();
        
        builder.HasOne(x => x.Plan)
            .WithMany()
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}