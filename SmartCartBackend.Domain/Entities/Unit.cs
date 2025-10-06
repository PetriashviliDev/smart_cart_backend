namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника единицы измерения
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
/// <param name="shortTitle">Сокращение</param>
public class Unit(
    int id,
    string title, 
    string shortTitle) 
    : SeedWork.Enumeration(id, title)
{
    public string ShortTitle { get; private set; } = shortTitle;

    #region Seeds
    
    public static Unit Gram = new(1, "Грамм", "г.");
    public static Unit Kilogram = new(2, "Килограмм", "кг.");
    public static Unit Piece = new(3, "Штук", "шт.");
    public static Unit Milliliter = new(4, "Миллилитр", "мл.");
    public static Unit Liter = new(5, "Литр", "л.");
    public static Unit Tablespoon = new(6, "Столовая ложка", "ст. л.");
    public static Unit Teaspoon = new(7, "Чайная ложка", "ч. л.");
    public static Unit Slice = new(8, "Ломтик", "ломтика");
    
    #endregion Seeds
}