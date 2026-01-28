using SmartCardBackend.Application.Nutrition.Dto;

namespace SmartCardBackend.Application.Nutrition;

public interface INutritionPlanEnricher
{
    Task<NutritionPlanResponse> EnrichAsync(
        NutritionPlanResponse plan, 
        CancellationToken ct = default);
}