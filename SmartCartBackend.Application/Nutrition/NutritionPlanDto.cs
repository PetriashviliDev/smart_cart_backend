namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanDto
{
    public List<NutritionPlanDayDto> Days { get; set; } = [];
}