using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanDay
{
    public int Day { get; set; }
    
    [JsonProperty("total_calories")]
    [JsonPropertyName("total_calories")]
    public decimal TotalCalories { get; set; }
    
    [JsonProperty("total_protein")]
    [JsonPropertyName("total_protein")]
    public decimal TotalProtein { get; set; }
    
    [JsonProperty("total_fat")]
    [JsonPropertyName("total_fat")]
    public decimal TotalFat { get; set; }
    
    [JsonProperty("total_carbs")]
    [JsonPropertyName("total_carbs")]
    public decimal TotalCarbs { get; set; }

    public List<NutritionMeal> Meals { get; set; } = [];
}