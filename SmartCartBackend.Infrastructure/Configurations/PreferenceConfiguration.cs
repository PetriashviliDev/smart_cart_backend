using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class PreferenceConfiguration : EnumerationEntityTypeConfiguration<Preference>
{
    public override void Configure(EntityTypeBuilder<Preference> builder)
    {
        builder.ToTable("Preferences");
        
        base.Configure(builder);
        
        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();
    }
}