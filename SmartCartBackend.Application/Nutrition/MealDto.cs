using System.Text.Json.Serialization;

namespace SmartCardBackend.Application.Nutrition;

public record MealDto
{
    public required string Type { get; set; }
    
    public required string Name { get; set; }
    
    public decimal Calories { get; set; }
    
    public decimal Protein { get; set; }
    
    public decimal Carb { get; set; }
    
    public decimal Fat { get; set; }

    public List<IngredientDto> Ingredients { get; set; } = [];

    [JsonPropertyName("recipe_steps")] 
    public List<string> RecipeSteps { get; set; } = [];

    [JsonPropertyName("cooking_time")]
    public int CookingTime { get; set; }
}