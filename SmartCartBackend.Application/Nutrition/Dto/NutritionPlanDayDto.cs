namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// День рациона
/// </summary>
public record NutritionPlanDayDto
{
    /// <summary>
    /// Номер дня
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Приемы пищи
    /// </summary>
    public List<NutritionMealDto> Meals { get; set; } = [];
}