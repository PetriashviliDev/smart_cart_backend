namespace SmartCardBackend.Application.Nutrition;

public record NutritionPlanSummary
{
    public decimal TotalCalories { get; set; }
    
    public decimal TotalProtein { get; set; }
    
    public decimal TotalFat { get; set; }
    
    public decimal TotalCarbs { get; set; }
    
    public decimal AverageDailyCalories { get; set; }
}