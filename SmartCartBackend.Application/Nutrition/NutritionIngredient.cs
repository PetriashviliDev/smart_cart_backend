namespace SmartCardBackend.Application.Nutrition;

public record NutritionIngredient
{
    public string Name { get; set; }
    
    public int Amount { get; set; }
    
    public string Unit { get; set; }
}