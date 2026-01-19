namespace SmartCardBackend.Domain.Entities.SeedWork;

public interface IHasId<out TIdentifier>
{
    public TIdentifier Id { get; }
}