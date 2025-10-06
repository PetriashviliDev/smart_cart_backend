using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Domain.Repositories;

public interface ISessionRepository : IRepository<Session>
{
    Task<Session> FindLastActiveAsync(
        string phone,
        bool trackingEnabled = true,
        CancellationToken ct = default);

    Task<Session> FindActiveAsync(
        Guid id,
        bool trackingEnabled = true,
        CancellationToken ct = default);
}