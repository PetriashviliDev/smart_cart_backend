namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public record DishExample
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Carbs { get; set; }
    public int CookingTime { get; set; }
    public List<IngredientExample> Ingredients { get; set; }
    public List<RecipeStepExample> RecipeSteps { get; set; }
}