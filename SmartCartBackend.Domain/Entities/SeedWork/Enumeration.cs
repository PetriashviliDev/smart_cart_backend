using System.Reflection;
using CaseConverter;

namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая доменная модель справочника
/// </summary>
public abstract class Enumeration : ISoftDeletable
{
    protected Enumeration(
        int id,
        string title,
        string internalName = null,
        bool isDeleted = false)
    {
        Id = id;
        Title = title;
        InternalName = internalName?.ToSnakeCase();
        IsDeleted = isDeleted;
    }
    protected Enumeration() { }
    
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Внутреннее наименование
    /// </summary>
    public string InternalName { get; private set; }

    /// <inheritdoc cref="ISoftDeletable"/>
    public bool IsDeleted { get; private set; }

    /// <inheritdoc cref="ISoftDeletable"/>
    public void SetIsDeleted(bool isDeleted = true) => IsDeleted = isDeleted;
    
    /// <summary>
    /// Получение всех значений справочника
    /// </summary>
    /// <typeparam name="TEntity">Тип справочника</typeparam>
    /// <returns>Список значений</returns>
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