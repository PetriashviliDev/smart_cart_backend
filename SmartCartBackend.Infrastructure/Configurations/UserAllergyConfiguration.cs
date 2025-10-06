using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserAllergyConfiguration : IEntityTypeConfiguration<UserAllergy>
{
    public void Configure(EntityTypeBuilder<UserAllergy> builder)
    {
        builder.ToTable("UserAllergies");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.AllergyId)
            .IsRequired();
        
        builder.HasOne(x => x.Allergy)
            .WithMany()
            .HasForeignKey(x => x.AllergyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Allergy).AutoInclude();
    }
}