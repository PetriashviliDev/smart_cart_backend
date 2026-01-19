using Newtonsoft.Json;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanDish
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Image { get; set; }
    
    public decimal Calories { get; set; }

    [JsonProperty("cooking_time_in_minutes")]
    public int CookingTimeInMinutes { get; set; }

    public List<NutritionPlanAlternativeDish> Alternatives { get; set; } = [];
}