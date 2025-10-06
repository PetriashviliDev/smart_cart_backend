using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель рациона
/// </summary>
public class MealPlan : Entity<int>
{
    #region Constructors

    [JsonConstructor]
    protected MealPlan(
        int id, 
        string name, 
        DateTime startDate, 
        DateTime endDate, 
        List<Meal> meals) : base(id)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        _meals = meals;
    }
    
    private MealPlan(
        int id, 
        string name, 
        DateTime startDate, 
        DateTime endDate) : base(id)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        _meals = [];
    }

    public static MealPlan Create(
        int id,
        string name,
        DateTime startDate,
        DateTime endDate)
    {
        var mealPlan = new MealPlan(id, name, startDate, endDate);
        return mealPlan;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Дата начала
    /// </summary>
    public DateTime StartDate { get; private set; }
    
    /// <summary>
    /// Дата окончания
    /// </summary>
    public DateTime EndDate { get; private set; }

    /// <summary>
    /// Приемы пищи
    /// </summary>
    public IReadOnlyCollection<Meal> Meals => _meals.AsReadOnly();

    private readonly List<Meal> _meals;
    
    /// <summary>
    /// Общее количество калорий
    /// </summary>
    public decimal TotalCalories => Meals.Sum(m => m.Dish.TotalCalories);
    
    /// <summary>
    /// Общее количество белка
    /// </summary>
    public decimal TotalProteins => Meals.Sum(m => m.Dish.TotalProteins);
    
    /// <summary>
    /// Общее количество жиров
    /// </summary>
    public decimal TotalFats => Meals.Sum(m => m.Dish.TotalFats);
    
    /// <summary>
    /// Общее количество углеводов
    /// </summary>
    public decimal TotalCarbohydrates => Meals.Sum(m => m.Dish.TotalCarbohydrates);
    
    #endregion Properties
}