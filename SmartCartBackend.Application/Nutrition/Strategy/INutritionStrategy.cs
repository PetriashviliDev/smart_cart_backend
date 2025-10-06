using SmartCardBackend.Application.Identity;

namespace SmartCardBackend.Application.Nutrition.Strategy;

public interface INutritionStrategy
{
    Task<NutritionPlan> GeneratePlanAsync(
        UserContext user, 
        NutritionRequirements requirements, 
        CancellationToken ct = default);
}