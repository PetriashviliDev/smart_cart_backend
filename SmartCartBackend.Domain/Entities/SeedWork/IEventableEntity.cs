using SmartCardBackend.Domain.Events;

namespace SmartCardBackend.Domain.Entities.SeedWork;

public interface IEventableEntity
{
    IReadOnlyCollection<IDomainEvent> PreDomainEvents { get; }
    void AddPreDomainEvent(IDomainEvent domainEvent);
    void ClearPreDomainEvents();
    
    IReadOnlyCollection<IDomainEvent> PostDomainEvents { get; }
    void AddPostDomainEvent(IDomainEvent domainEvent);
    void ClearPostDomainEvents();
}