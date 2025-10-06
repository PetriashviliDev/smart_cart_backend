using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class MealPlansConfiguration : IEntityTypeConfiguration<MealPlan>
{
    public void Configure(EntityTypeBuilder<MealPlan> builder)
    {
        builder.ToTable("MealPlans");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.StartDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
        
        builder.Property(x => x.EndDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
        
        builder.HasMany(x => x.Meals)
            .WithOne(x => x.MealPlan)
            .HasForeignKey(x => x.MealPlanId);
    }
}