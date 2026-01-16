using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {
        builder.ToTable("UserPreferences");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.DishId)
            .IsRequired();
        
        builder.HasOne(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.MealTypeId)
            .IsRequired();
        
        builder.HasOne(x => x.MealType)
            .WithMany()
            .HasForeignKey(x => x.MealTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Dish)
            .AutoInclude();
        
        builder.Navigation(x => x.MealType)
            .AutoInclude();
    }
}