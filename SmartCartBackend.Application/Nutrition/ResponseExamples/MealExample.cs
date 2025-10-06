namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public record MealExample
{
    public string Type { get; set; }
    public List<DishExample> Dishes { get; set; }
}