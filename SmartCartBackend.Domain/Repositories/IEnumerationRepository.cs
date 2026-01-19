using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Repositories;

/// <summary>
/// Репозиторий по работе со справочниками
/// </summary>
public interface IEnumerationRepository
{
    /// <summary>
    /// Получение значений справочника
    /// </summary>
    Task<List<TEnumeration>> GetEnumerationItemsAsync<TEnumeration>(
        CancellationToken ct = default)
        where TEnumeration : ActualizedEnumeration<TEnumeration>;
    
    /// <summary>
    /// Создание или обновление значения справочника
    /// </summary>
    Task CreateOrUpdateEnumerationItem<TEnumeration>(
        TEnumeration enumeration, 
        CancellationToken ct = default)
        where TEnumeration : ActualizedEnumeration<TEnumeration>;
    
    /// <summary>
    /// Удаление значения справочника
    /// </summary>
    Task DeleteEnumerationItem<TEnumeration>(
        int id, 
        CancellationToken ct = default)
        where TEnumeration : ActualizedEnumeration<TEnumeration>;
}