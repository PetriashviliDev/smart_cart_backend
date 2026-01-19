using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Время дня приема пищи
/// </summary>
public class MealType : ActualizedEnumeration<MealType>
{
    private MealType() { }

    public MealType(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }
    
    #region Seeds

    public static MealType Breakfast = new(1, "Завтрак");
    public static MealType Lunch = new(2, "Обед");
    public static MealType Snack = new(3, "Перекус");
    public static MealType Dinner = new(4, "Ужин");
    
    #endregion Seeds
}