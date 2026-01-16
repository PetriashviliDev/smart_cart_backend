using SmartCardBackend.Application.Nutrition.Pipeline.Models;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public interface INutritionPlanGenerationPipelineStep
{
    Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default);
}