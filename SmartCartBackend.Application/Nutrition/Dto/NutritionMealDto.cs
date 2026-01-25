using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Прием пищи
/// </summary>
public record NutritionMealDto
{
    /// <summary>
    /// Тип приема пищи
    /// </summary>
    public Pair<int> Type { get; set; }

    /// <summary>
    /// Основные блюда
    /// </summary>
    public List<NutritionPlanDishDto> Dishes { get; set; }
}