namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника трудности приготовления
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
public class Difficulty(
    int id,
    string title)
    : SeedWork.Enumeration(id, title)
{
    #region Seeds

    /// <summary>
    /// Легко
    /// </summary>
    public static Difficulty Easy = new(1, "Легко");
    
    /// <summary>
    /// Средне
    /// </summary>
    public static Difficulty Normal = new(2, "Средне");
    
    /// <summary>
    /// Сложно
    /// </summary>
    public static Difficulty Hard = new(3, "Сложно");
    
    #endregion Seeds
}