using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Nutrition.Dto;

public record NutritionPlanIngredientDto
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
    /// Количество
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public Pair<int> Unit { get; set; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public Pair<int> Category { get; set; }
}