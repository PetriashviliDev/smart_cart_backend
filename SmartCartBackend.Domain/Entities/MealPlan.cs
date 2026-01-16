using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель рациона
/// </summary>
public class MealPlan : Entity<int>
{
    #region Constructors

    private MealPlan(int id) : base(id) { }
    
    [JsonConstructor]
    protected MealPlan(
        int id, 
        string name, 
        DateTimeOffset startDate, 
        DateTimeOffset endDate, 
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
        DateTimeOffset startDate, 
        DateTimeOffset endDate) : base(id)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        _meals = [];
    }

    public static MealPlan Create(
        int id,
        string name,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
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
    public DateTimeOffset StartDate { get; private set; }
    
    /// <summary>
    /// Дата окончания
    /// </summary>
    public DateTimeOffset EndDate { get; private set; }

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