using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishTagConfiguration : IEntityTypeConfiguration<DishTag>
{
    public void Configure(EntityTypeBuilder<DishTag> builder)
    {
        builder.ToTable("DishTags");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.DishId)
            .IsRequired();
        
        builder.Property(x => x.TagId)
            .IsRequired();
        
        builder.HasOne(x => x.Dish)
            .WithMany(x => x.DishTags)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.DishTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => new { x.DishId, x.TagId })
            .IsUnique();
    }
}