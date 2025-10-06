using System.Reflection;

namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая доменная модель справочника
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
public abstract class Enumeration(int id, string title)
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; private set; } = id;
    
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; private set; } = title;

    /// <summary>
    /// Признак удаления
    /// </summary>
    public bool IsDeleted { get; private set; }
    
    /// <summary>
    /// Установка признака удаления
    /// </summary>
    /// <param name="isDeleted">Признак удаления</param>
    public void SetIsDeleted(bool isDeleted = true) => IsDeleted = isDeleted;
    
    public static IEnumerable<TEntity> GetValues<TEntity>()
    {
        var type = typeof(TEntity);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
        
        foreach (var field in fields)
        {
            var value = field.GetValue(null);
            if (value is TEntity enumeration)
                yield return enumeration;
        }
    }
}