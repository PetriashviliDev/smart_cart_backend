namespace SmartCardBackend.Application.Nutrition.Pipeline.Models;

/// <summary>
/// Результат генерации рациона
/// </summary>
public record NutritionPlanGenerationResult
{
    /// <summary>
    /// Сгенерированный план питания
    /// </summary>
    public NutritionPlan Plan { get; set; }
}