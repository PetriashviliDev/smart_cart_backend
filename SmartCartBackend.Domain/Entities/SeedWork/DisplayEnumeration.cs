namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая расширенная доменная модель справочника
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
/// <param name="description">Описание</param>
/// <param name="image">Изображение</param>
public abstract class DisplayEnumeration(
    int id,
    string title, 
    string description, 
    string image) 
    : Enumeration(id, title)
{
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; private set; } = description;

    /// <summary>
    /// Изображение
    /// </summary>
    public string Image { get; private set; } = image;
}