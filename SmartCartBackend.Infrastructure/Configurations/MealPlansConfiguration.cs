using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class MealPlansConfiguration : IEntityTypeConfiguration<MealPlan>
{
    public void Configure(EntityTypeBuilder<MealPlan> builder)
    {
        builder.ToTable("MealPlans");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.StartDate)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.EndDate)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.HasMany(x => x.Meals)
            .WithOne(x => x.MealPlan)
            .HasForeignKey(x => x.MealPlanId);
    }
}