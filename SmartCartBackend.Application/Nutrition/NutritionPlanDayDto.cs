namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanDayDto
{
    public int Number { get; set; }

    public List<NutritionMealDto> Meals { get; set; } = [];
}