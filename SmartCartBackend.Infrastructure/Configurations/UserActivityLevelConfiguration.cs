using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserActivityLevelConfiguration : EnumerationEntityTypeConfiguration<UserActivityLevel>
{
    public override void Configure(EntityTypeBuilder<UserActivityLevel> builder)
    {
        builder.ToTable("UserActivityLevels");
        
        base.Configure(builder);
    }
}