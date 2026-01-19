using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Events;

namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Базовая доменная модель
/// </summary>
/// <param name="id">Идентификатор</param>
public abstract class Entity<TIdentifier>(TIdentifier id) : IEventable, IHasId<TIdentifier>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public TIdentifier Id { get; private set; } = id;

    [JsonIgnore] public IReadOnlyCollection<IDomainEvent> PreDomainEvents => _preDomainEvents.AsReadOnly();
    private readonly List<IDomainEvent> _preDomainEvents = [];
    
    public void AddPreDomainEvent(IDomainEvent domainEvent) => _preDomainEvents.Add(domainEvent);
    
    public void ClearPreDomainEvents() => _preDomainEvents.Clear();
    
    [JsonIgnore] public IReadOnlyCollection<IDomainEvent> PostDomainEvents => _postDomainEvents.AsReadOnly();
    private readonly List<IDomainEvent> _postDomainEvents = [];
    
    public void AddPostDomainEvent(IDomainEvent domainEvent) => _postDomainEvents.Add(domainEvent);
    
    public void ClearPostDomainEvents() => _postDomainEvents.Clear();
}