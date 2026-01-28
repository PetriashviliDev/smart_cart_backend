using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Блюдо
/// </summary>
public record NutritionPlanDishDto
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
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Картинка
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// Сложность
    /// </summary>
    public Pair<int> Difficulty { get; set; }
    
    /// <summary>
    /// Калории
    /// </summary>
    public decimal Calories { get; set; }

    /// <summary>
    /// Время готовки в минутах
    /// </summary>
    public int CookingTimeInMinutes { get; set; }

    /// <summary>
    /// Роль блюда в рационе
    /// </summary>
    public DishRole Role { get; set; }

    /// <summary>
    /// Шаги приготовления
    /// </summary>
    public List<NutritionPlanRecipeStepDto> RecipeSteps { get; set; } = [];

    /// <summary>
    /// Ингредиенты
    /// </summary>
    public List<NutritionPlanIngredientDto> Ingredients { get; set; } = [];
}