using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Models;

/// <summary>
/// Запрос на генерацию рациона
/// </summary>
public record NutritionPlanGenerationRequest
{
    /// <summary>
    /// Контекстный пользователь
    /// </summary>
    public UserContext User { get; set; }

    /// <summary>
    /// Требования
    /// </summary>
    public NutritionRequirements Requirements { get; set; }
}