namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public record IngredientExample
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public string Unit { get; set; }
}