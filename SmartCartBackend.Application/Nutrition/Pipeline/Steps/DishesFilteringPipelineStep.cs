using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Searchers;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class DishesFilteringPipelineStep(
    IDishSearcher searcher) : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}