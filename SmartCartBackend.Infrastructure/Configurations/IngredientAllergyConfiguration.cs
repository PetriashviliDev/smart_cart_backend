using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class IngredientAllergyConfiguration : IEntityTypeConfiguration<IngredientAllergy>
{
    public void Configure(EntityTypeBuilder<IngredientAllergy> builder)
    {
        builder.ToTable("IngredientAllergies");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.IngredientId)
            .IsRequired();
        
        builder.Property(x => x.AllergyId)
            .IsRequired();
        
        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Allergy)
            .WithMany()
            .HasForeignKey(x => x.AllergyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(x => new { x.IngredientId, x.AllergyId })
            .IsUnique();
    }
}