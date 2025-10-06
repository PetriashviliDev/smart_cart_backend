using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserIntoleranceConfiguration : IEntityTypeConfiguration<UserIntolerance>
{
    public void Configure(EntityTypeBuilder<UserIntolerance> builder)
    {
        builder.ToTable("UserIntolerances");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).
            ValueGeneratedNever();
        
        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.IntoleranceId)
            .IsRequired();
        
        builder.HasOne(x => x.Intolerance)
            .WithMany()
            .HasForeignKey(x => x.IntoleranceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Intolerance).AutoInclude();
    }
}