using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Searchers;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class DishesSearchingPipelineStep(
    IDishSearcher searcher) 
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        context.SimilarDishes = await searcher.SearchSimilarAsync(
            context.EmbeddingQuery, ct: ct);
    }
}