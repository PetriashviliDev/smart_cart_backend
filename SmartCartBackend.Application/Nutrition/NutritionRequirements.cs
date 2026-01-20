using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionRequirements
{
    /// <summary>
    /// Количество дней в рационе
    /// </summary>
    public int NutritionDays { get; set; }
    
    /// <summary>
    /// Желаемое время на готовку
    /// </summary>
    public int? CookingTimeInMinutes { get; set; }
    
    /// <summary>
    /// Количество приемов пищи в день
    /// </summary>
    public int MealsCountPerDay { get; set; }

    /// <summary>
    /// Стратегия рациона
    /// </summary>
    public Pair<int> Strategy { get; set; }
}