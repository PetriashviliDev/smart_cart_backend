using System.Text.Json.Serialization;

namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlan
{
    [JsonPropertyName("weekly_plan")]
    public List<PlanItem> WeeklyPlan { get; set; } = [];

    public NutritionPlanSummary Summary { get; set; }
}