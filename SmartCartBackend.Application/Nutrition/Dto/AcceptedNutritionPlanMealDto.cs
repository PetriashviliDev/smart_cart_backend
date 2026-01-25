using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Прием пищи
/// </summary>
public record AcceptedNutritionPlanMealDto
{
    /// <summary>
    /// Тип приема пищи
    /// </summary>
    public Pair<int> Type { get; set; }

    /// <summary>
    /// Основные блюда
    /// </summary>
    public List<AcceptedNutritionPlanDishDto> Dishes { get; set; }
}