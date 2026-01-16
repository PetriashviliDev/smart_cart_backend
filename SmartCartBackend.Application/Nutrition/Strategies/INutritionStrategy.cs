using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.Nutrition.Strategies;

public interface INutritionStrategy
{
    Task<NutritionPlan> GeneratePlanAsync(
        UserContext user, 
        NutritionRequirements requirements, 
        CancellationToken ct = default);
}