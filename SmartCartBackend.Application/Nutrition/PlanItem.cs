using System.Text.Json.Serialization;

namespace SmartCardBackend.Application.Nutrition;

public record PlanItem
{
    public required string Day { get; set; }
    
    [JsonPropertyName("total_calories")]
    public decimal TotalCalories { get; set; }
}