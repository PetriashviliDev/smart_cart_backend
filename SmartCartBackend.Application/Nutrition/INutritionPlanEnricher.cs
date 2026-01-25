namespace SmartCardBackend.Application.Nutrition;

public interface INutritionPlanEnricher
{
    Task<NutritionPlanDto> EnrichAsync(
        NutritionPlanDto plan, 
        CancellationToken ct = default);
}