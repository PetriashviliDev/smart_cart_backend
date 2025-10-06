namespace SmartCardBackend.Application.Nutrition;

public record IngredientDto
{
    public required string Name { get; set; }
    
    public int Amount { get; set; }
    
    public required string Unit { get; set; }
}