namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Группа блюд
/// </summary>
public record AcceptedNutritionPlanMealGroupDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Блюда
    /// </summary>
    public List<AcceptedNutritionPlanDishDto> Dishes { get; set; } = [];
}