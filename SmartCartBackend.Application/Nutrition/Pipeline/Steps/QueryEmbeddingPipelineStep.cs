using SmartCardBackend.Application.Extensions;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Embedding;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class QueryEmbeddingPipelineStep(
    IEmbeddingService embeddingService) 
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        var embeddingResult = await embeddingService.EmbedAsync(
            new EmbedRequest(context.RawQuery), ct);

        context.EmbeddingQuery = embeddingResult.Embeddings.ToVector();
    }
}