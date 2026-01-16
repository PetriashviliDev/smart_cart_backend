using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionDish
{
    public string Name { get; set; }
    
    public decimal Calories { get; set; }
    
    public decimal Protein { get; set; }
    
    public decimal Fat { get; set; }
    
    public decimal Carbs { get; set; }

    [JsonProperty("cooking_time_in_minutes")]
    [JsonPropertyName("cooking_time_in_minutes")]
    public int CookingTimeInMinutes { get; set; }
    
    public List<NutritionIngredient> Ingredients { get; set; } = [];
    
    [JsonProperty("recipe_steps")]
    [JsonPropertyName("recipe_steps")]
    public List<NutritionRecipeStep> RecipeSteps { get; set; } = [];
}