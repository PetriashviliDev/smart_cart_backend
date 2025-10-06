using System.Text.Json.Serialization;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanSummary
{
    [JsonPropertyName("total_calories")]
    public decimal TotalCalories { get; set; }
    
    [JsonPropertyName("total_protein")]
    public decimal TotalProtein { get; set; }
    
    [JsonPropertyName("total_fat")]
    public decimal TotalFat { get; set; }
    
    [JsonPropertyName("total_carbs")]
    public decimal TotalCarbs { get; set; }
    
    [JsonPropertyName("average_daily_calories")]
    public decimal AverageDailyCalories { get; set; }
}