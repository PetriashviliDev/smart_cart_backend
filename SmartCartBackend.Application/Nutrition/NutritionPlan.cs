namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlan
{
    public List<NutritionPlanDay> Days { get; set; } = [];
}