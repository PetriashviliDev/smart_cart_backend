namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public class DayPlanExample
{
    public string Day { get; set; }

    public List<MealExample> Meals { get; set; }
    
    public int TotalCalories { get; set; }
    
    public int TotalProtein { get; set; }
    
    public int TotalFat { get; set; }
    
    public int TotalCarbs { get; set; }
}