using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class UserAiRequestConfiguration : IEntityTypeConfiguration<UserAiRequest>
{
    public void Configure(EntityTypeBuilder<UserAiRequest> builder)
    {
        builder.ToTable("UserAiRequests");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.Provider)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(x => x.Model)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(x => x.RequestedAt)
            .HasDateTimeOffsetConversion()
            .IsRequired();
        
        builder.Property(x => x.DurationMs)
            .HasColumnType("bigint")
            .IsRequired();
        
        builder.Property(x => x.Status)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(x => x.ErrorText)
            .IsRequired(false);
        
        builder.Property(x => x.PromptTokens)
            .IsRequired(false);
        
        builder.Property(x => x.CompletionTokens)
            .IsRequired(false);
        
        builder.Property(x => x.TotalTokens)
            .IsRequired(false);
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.UserId, x.RequestedAt });
        builder.HasIndex(x => new { x.Status, x.RequestedAt });
        builder.HasIndex(x => new { x.Provider, x.Model, x.RequestedAt });

        builder.Navigation(x => x.User)
            .AutoInclude();
    }
}