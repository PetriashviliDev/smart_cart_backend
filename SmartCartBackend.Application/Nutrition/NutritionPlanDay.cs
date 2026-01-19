namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanDay
{
    public int Number { get; set; }

    public List<NutritionMeal> Meals { get; set; } = [];
}