using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class DishEmbeddingConfiguration : IEntityTypeConfiguration<DishEmbedding>
{
    public void Configure(EntityTypeBuilder<DishEmbedding> builder)
    {
        builder.ToTable("DishEmbeddings");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.Model)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(x => x.Dimensions)
            .IsRequired()
            .HasDefaultValue(384);

        builder.Property(x => x.TextVersion)
            .IsRequired();

        builder.Property(x => x.ContentHash)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.Embedding)
            .HasColumnType("vector(384)")
            .IsRequired();

        builder.HasIndex(x => x.Model);
        builder.HasIndex(x => new { x.Model, x.TextVersion });
        
        builder.HasIndex(e => e.Embedding)
            .HasMethod("ivfflat")
            .HasOperators("vector_cosine_ops");
        
        builder.HasIndex(x => x.DishId)
            .IsUnique();
    }
}