using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionMeal
{
    /// <summary>
    /// Тип приема пищи
    /// </summary>
    public Pair<int> Type { get; set; }

    /// <summary>
    /// Основные блюда
    /// </summary>
    public List<NutritionPlanDish> Dishes { get; set; }
}