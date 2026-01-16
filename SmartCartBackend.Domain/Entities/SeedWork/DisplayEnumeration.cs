namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая расширенная доменная модель справочника
/// </summary>
public abstract class DisplayEnumeration : Enumeration
{
    protected DisplayEnumeration() { }

    protected DisplayEnumeration(
        int id,
        string title, 
        string description, 
        string image, 
        string internalName) : base(id, title, internalName)
    {
        Description = description;
        Image = image;
    }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Изображение
    /// </summary>
    public string Image { get; private set; }
}