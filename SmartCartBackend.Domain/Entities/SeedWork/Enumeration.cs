using System.Collections.Concurrent;
using System.Reflection;
using CaseConverter;
using SmartCardBackend.Domain.Extensions;

namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая доменная модель справочника
/// </summary>
public abstract class Enumeration : ISoftDeletable, IHasId<int>
{
    private static readonly ConcurrentDictionary<Type, List<Enumeration>> Cache = new();
    private static readonly SemaphoreSlim Lock = new(1, 1);
    
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
    
    /// <summary>
    /// Установка названия
    /// </summary>
    public void SetTitle(string title) => Title = title;
    
    /// <summary>
    /// Установка внутреннего названия
    /// </summary>
    public void SetInternalName(string internalName) => InternalName = internalName;

    /// <inheritdoc cref="ISoftDeletable"/>
    public void SetIsDeleted(bool isDeleted = true) => IsDeleted = isDeleted;

    /// <summary>
    /// Признак добавленного из вне элемента
    /// </summary>
    public bool IsAdded { get; private set; }
    
    /// <summary>
    /// Получение сидов справочника
    /// </summary>
    public static IEnumerable<TEnumeration> GetSeeds<TEnumeration>()
        where TEnumeration : Enumeration
    {
        var type = typeof(TEnumeration);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
        
        foreach (var field in fields)
        {
            var value = field.GetValue(null);
            if (value is TEnumeration enumeration)
                yield return enumeration;
        }
    }
    
    /// <summary>
    /// Получение сидов справочника
    /// </summary>
    public static IEnumerable<Enumeration> GetSeeds(Type enumerationType)
    {
        var fields = enumerationType.GetFields(BindingFlags.Public | BindingFlags.Static);
        
        foreach (var field in fields)
        {
            var value = field.GetValue(null);
            if (value?.GetType() == enumerationType)
                yield return (Enumeration)value;
        }
    }

    /// <summary>
    /// Добавление элемента в справочник
    /// </summary>
    public static void Add<TEnumeration>(TEnumeration enumeration)
        where TEnumeration : Enumeration
    {
        Lock.Wait();

        try
        {
            var items = GetCached(typeof(TEnumeration)).ToList();

            if (items.Any(i => i.Id == enumeration.Id || i.InternalName.EqualsIgnoreCase(i.InternalName)))
                return;

            if (enumeration.Id == 0)
                enumeration.Id = enumeration.GetNextId();

            enumeration.IsAdded = true;

            Cache[typeof(TEnumeration)]
                .Add(enumeration);
        }
        finally
        {
            Lock.Release();
        }
    }

    /// <summary>
    /// Удаление элемента из справочника
    /// </summary>
    public static void Remove<TEnumeration>(int id)
        where TEnumeration : Enumeration
    {
        Lock.Wait();

        try
        {
            var item = GetCached(typeof(TEnumeration))
                .FirstOrDefault(i => i.Id == id && i.IsAdded);

            Cache[typeof(TEnumeration)]
                .Remove(item);
        }
        finally
        {
            Lock.Release();
        }
    }

    /// <summary>
    /// Сброс всего кеша
    /// </summary>
    public static void Flush() => Cache.Clear();
    
    /// <summary>
    /// Сброс кеша по конкретному типу
    /// </summary>
    public static void Flush(Type enumerationType) =>
        Cache.TryRemove(enumerationType, out _);

    /// <summary>
    /// Получение следующего идентификатора
    /// </summary>
    /// <returns></returns>
    protected virtual int GetNextId()
    {
        var items = GetCached(GetType()).ToList();
        return items.Count != 0 ? items.Max(i => i.Id) + 1 : 1;
    }

    /// <summary>
    /// Получение элементов из кеша
    /// </summary>
    public static IEnumerable<Enumeration> GetCached(Type enumerationType)
    {
        if (!enumerationType.HasBaseType(typeof(Enumeration)))
            return [];

        if (Cache.TryGetValue(enumerationType, out var items))
            return items;

        items = GetSeeds(enumerationType).ToList();

        Cache.AddOrUpdate(
            enumerationType,
            _ => items,
            (_, _) => items);

        return items;
    }

    /// <summary>
    /// Получение элементов справочника из кеша
    /// </summary>
    public static IEnumerable<TEnumeration> GetCached<TEnumeration>()
        where TEnumeration : Enumeration => 
        GetCached(typeof(TEnumeration)).OfType<TEnumeration>();

    /// <summary>
    /// Получение элемента справочника по идентификатору
    /// </summary>
    public static TEnumeration FromId<TEnumeration>(int id)
        where TEnumeration : Enumeration
    {
        var item = GetCached<TEnumeration>()
            .FirstOrDefault(i => i.Id == id);

        return item;
    }
    
    /// <summary>
    /// Получение элемента справочника по внутреннему названию
    /// </summary>
    public static TEnumeration FromInternalName<TEnumeration>(string internalName)
        where TEnumeration : Enumeration
    {
        var item = GetCached<TEnumeration>()
            .FirstOrDefault(i => i.InternalName.EqualsIgnoreCase(internalName));

        return item;
    }
}