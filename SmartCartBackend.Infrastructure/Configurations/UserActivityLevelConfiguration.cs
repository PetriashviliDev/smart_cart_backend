using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserActivityLevelConfiguration : EnumerationEntityTypeConfiguration<ActivityLevel>
{
    public override void Configure(EntityTypeBuilder<ActivityLevel> builder)
    {
        builder.ToTable("ActivityLevels");
        
        base.Configure(builder);
    }
}