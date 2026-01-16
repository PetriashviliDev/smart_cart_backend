using SmartCardBackend.Application.Nutrition.Pipeline.Models;

namespace SmartCardBackend.Application.Nutrition.Pipeline;

public interface INutritionPlanGenerationPipeline
{
    Task<NutritionPlanGenerationResult> GenerateAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default);
}