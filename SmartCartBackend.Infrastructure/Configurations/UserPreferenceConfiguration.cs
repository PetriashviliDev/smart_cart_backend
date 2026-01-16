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
        
        builder.Property(x => x.PreferenceId)
            .IsRequired();
        
        builder.HasOne(x => x.Preference)
            .WithMany()
            .HasForeignKey(x => x.PreferenceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Preference)
            .AutoInclude();
    }
}