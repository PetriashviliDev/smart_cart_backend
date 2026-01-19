namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая расширенная доменная модель справочника
/// </summary>
public abstract class DisplayEnumeration : ActualizedEnumeration<DisplayEnumeration>
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
    
    /// <summary>
    /// Установка описания
    /// </summary>
    public void SetDescription(string description) => Description = description;
    
    /// <summary>
    /// Установка изображения
    /// </summary>
    public void SetImage(string image) => Image = image;

    public override void Actualize(
        DisplayEnumeration enumeration)
    {
        base.Actualize(enumeration);
        
        SetDescription(enumeration.Description);
        SetImage(enumeration.Image);
    }
}