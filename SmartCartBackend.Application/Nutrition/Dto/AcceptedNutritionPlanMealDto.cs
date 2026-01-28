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
    /// Группа блюд
    /// </summary>
    public List<AcceptedNutritionPlanMealGroupDto> Groups { get; set; } = [];
}