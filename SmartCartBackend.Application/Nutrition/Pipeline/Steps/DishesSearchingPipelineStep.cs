using Microsoft.Extensions.Options;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Options;
using SmartCardBackend.Application.Services.Searchers;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class DishesSearchingPipelineStep(
    IOptions<VectorSearchOptions> options,
    IDishSearcher searcher) 
    : INutritionPlanGenerationPipelineStep
{
    private readonly VectorSearchOptions _vectorSearchOptions = options.Value;
    
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        context.SimilarDishes = await searcher.SearchSimilarAsync(
            context.EmbeddingQuery, 
            _vectorSearchOptions.Batch,
            _vectorSearchOptions.SimilarityThreshold,
            ct);
    }
}