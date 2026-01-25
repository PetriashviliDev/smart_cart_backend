namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// День рациона
/// </summary>
public record AcceptedNutritionPlanDayDto
{
    /// <summary>
    /// Номер дня в рационе
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Приемы пищи
    /// </summary>
    public List<AcceptedNutritionPlanMealDto> Meals { get; set; } = [];
}