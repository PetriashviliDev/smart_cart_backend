using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure.Configurations;

public class NutritionPlanDraftConfiguration : IEntityTypeConfiguration<NutritionPlanDraft>
{
    public void Configure(EntityTypeBuilder<NutritionPlanDraft> builder)
    {
        builder.ToTable("NutritionPlanDrafts");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.CreatedDate)
            .HasDateTimeOffsetConversion()
            .IsRequired();

        builder.Property(x => x.PlanJson)
            .HasColumnType("jsonb")
            .IsRequired();
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}