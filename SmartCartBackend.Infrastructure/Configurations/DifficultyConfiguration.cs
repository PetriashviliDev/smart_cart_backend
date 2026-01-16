using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DifficultyConfiguration : EnumerationEntityTypeConfiguration<Difficulty>
{
    public override void Configure(EntityTypeBuilder<Difficulty> builder)
    {
        builder.ToTable("Difficulty");
        
        base.Configure(builder);
    }
}