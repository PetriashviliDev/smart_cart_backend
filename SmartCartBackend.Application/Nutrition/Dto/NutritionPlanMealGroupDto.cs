namespace SmartCardBackend.Application.Nutrition.Dto;

public record NutritionPlanMealGroupDto
{
    public int Id { get; set; }

    public List<NutritionPlanDishDto> Dishes { get; set; } = [];
}