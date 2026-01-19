using SmartCardBackend.Application.Responses;

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
    /// Стратегия рациона
    /// </summary>
    public Pair<int> Strategy { get; set; }

    /// <summary>
    /// Предпочтения на завтрак
    /// </summary>
    public List<Pair<int>> BreakfastPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на обед
    /// </summary>
    public List<Pair<int>> LunchPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на перекус
    /// </summary>
    public List<Pair<int>> SnackPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на ужин
    /// </summary>
    public List<Pair<int>> DinnerPreferences { get; set; } = [];
}