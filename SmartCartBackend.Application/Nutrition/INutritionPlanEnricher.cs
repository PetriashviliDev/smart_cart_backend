namespace SmartCardBackend.Application.Nutrition;

public interface INutritionPlanEnricher
{
    Task<NutritionPlan> EnrichAsync(
        NutritionPlan plan, 
        CancellationToken ct = default);
}