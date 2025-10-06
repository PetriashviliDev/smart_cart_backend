using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishCategoryConfiguration : IEntityTypeConfiguration<DishCategory>
{
    public void Configure(EntityTypeBuilder<DishCategory> builder)
    {
        builder.ToTable("DishCategories");
        
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
        
        builder.HasMany(x => x.Dishes)
            .WithOne(x => x.DishCategory)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}