namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Шаг приготовления
/// </summary>
public record NutritionPlanRecipeStepDto
{
    /// <summary>
    /// Порядковый номер
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
}