namespace SmartCardBackend.Application.Nutrition;

public record NutritionRecipeStep
{
    public int Number { get; set; }
    
    public string Description { get; set; }
}