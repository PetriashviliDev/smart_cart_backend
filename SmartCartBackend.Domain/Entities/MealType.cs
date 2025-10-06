namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Тип приема пищи
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
public class MealType(
    int id,
    string title)
    : SeedWork.Enumeration(id, title)
{
    #region Seeds
    
    /// <summary>
    /// Завтрак
    /// </summary>
    public static MealType Breakfast = new(1, "Завтрак");
    
    /// <summary>
    /// Обед
    /// </summary>
    public static MealType Lunch = new(2, "Обед");
    
    /// <summary>
    /// Перекус
    /// </summary>
    public static MealType Snack = new(3, "Перекус");
    
    /// <summary>
    /// Ужин
    /// </summary>
    public static MealType Dinner = new(4, "Ужин");
    
    #endregion Seeds
}