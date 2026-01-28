using SmartCardBackend.Application.Nutrition.Dto;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Models;

/// <summary>
/// Результат генерации рациона
/// </summary>
public record NutritionPlanGenerationResult
{
    /// <summary>
    /// Сгенерированный план питания
    /// </summary>
    public NutritionPlanResponse Plan { get; set; }
}