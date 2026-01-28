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
    /// Группа блюд
    /// </summary>
    public List<NutritionPlanMealGroupDto> Groups { get; set; } = [];
}