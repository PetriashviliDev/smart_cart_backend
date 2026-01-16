using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionMeal
{
    public string Type { get; set; }

    public NutritionDish Dish { get; set; }
    
    [JsonProperty("alternative_dishes")]
    [JsonPropertyName("alternative_dishes")]
    public List<NutritionDish> AlternativeDishes { get; set; } = [];
}