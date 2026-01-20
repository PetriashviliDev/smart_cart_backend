using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishConfiguration : EnumerationEntityTypeConfiguration<Dish>
{
    public override void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");
        
        base.Configure(builder);
        
        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();
        
        builder.Property(x => x.Image)
            .HasMaxLength(128)
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
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.DishIngredients)
            .WithOne(x => x.Dish)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.DishEmbedding)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(x => x.Difficulty)
            .AutoInclude();
        
        builder.Navigation(x => x.DishIngredients)
            .AutoInclude();
        
        builder.Navigation(x => x.DishEmbedding)
            .AutoInclude();
    }
}