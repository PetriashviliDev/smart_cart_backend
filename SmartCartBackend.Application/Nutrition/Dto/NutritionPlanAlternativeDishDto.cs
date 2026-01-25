namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Блюдо-альтернатива
/// </summary>
public record NutritionPlanAlternativeDishDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Картинка
    /// </summary>
    public string Image { get; set; }
    
    /// <summary>
    /// Калории
    /// </summary>
    public decimal Calories { get; set; }

    /// <summary>
    /// Время готовки в минутах
    /// </summary>
    public int CookingTimeInMinutes { get; set; }

    /// <summary>
    /// Ингредиенты
    /// </summary>
    public List<NutritionPlanIngredientDto> Ingredients { get; set; } = [];
}