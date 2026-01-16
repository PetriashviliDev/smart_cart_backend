using SmartCardBackend.Application.Nutrition.Pipeline.Models;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class QueryEmbeddingPipelineStep : INutritionPlanGenerationPipeline
{
    public async Task<NutritionPlanGenerationResult> GenerateAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}