namespace SmartCardBackend.Application.Nutrition;

public record NutritionRequirements
{
    public string Budget { get; set; }
    
    public List<string> Cuisines { get; set; }
    
    public int CookingTimeInMinutes { get; set; }
    
    public int MealsCountPerDay { get; set; }
}