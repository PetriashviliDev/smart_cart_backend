using SmartCardBackend.Application.Dto;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionRequirements
{
    /// <summary>
    /// Желаемое время на готовку
    /// </summary>
    public int CookingTimeInMinutes { get; set; }
    
    /// <summary>
    /// Количество приемов пищи в день
    /// </summary>
    public int MealsCountPerDay { get; set; }
    
    /// <summary>
    /// Предпочтения на завтрак
    /// </summary>
    public List<DishDto> BreakfastPreferences { get; set; }
    
    /// <summary>
    /// Предпочтения на обед
    /// </summary>
    public List<DishDto> LunchPreferences { get; set; }
    
    /// <summary>
    /// Предпочтения на перекус
    /// </summary>
    public List<DishDto> SnackPreferences { get; set; }
    
    /// <summary>
    /// Предпочтения на ужин
    /// </summary>
    public List<DishDto> DinnerPreferences { get; set; }
}