using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class AllergyCategoryConfiguration : IEntityTypeConfiguration<AllergyCategory>
{
    public void Configure(EntityTypeBuilder<AllergyCategory> builder)
    {
        builder.ToTable("AllergyCategories");
        
        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();

        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();
    }
}