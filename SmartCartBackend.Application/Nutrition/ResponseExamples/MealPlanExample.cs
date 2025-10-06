using Newtonsoft.Json;

namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public record MealPlanExample
{
    [JsonProperty("weekly_plan")]
    public List<DayPlanExample> WeeklyPlan { get; set; }

    [JsonProperty("total_calories")]
    public int TotalCalories { get; set; }
    
    [JsonProperty("average_daily_calories")]
    public int AverageDailyCalories { get; set; }
    
    [JsonProperty("total_protein")]
    public int TotalProtein { get; set; }
    
    [JsonProperty("total_fat")]
    public int TotalFat { get; set; }
    
    [JsonProperty("total_carbs")]
    public int TotalCarbs { get; set; }
}