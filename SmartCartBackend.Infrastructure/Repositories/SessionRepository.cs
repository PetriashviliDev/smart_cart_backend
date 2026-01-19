using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;
using SmartCartBackend.Common.Clock;

namespace SmartCartBackend.Infrastructure.Repositories;

public class SessionRepository(
    ISystemClock clock,
    DatabaseContext context) 
    : Repository<Session, Guid>(context), ISessionRepository
{
    public async Task<Session> FindLastActiveAsync(
        string phone,
        bool trackingEnabled = true,
        CancellationToken ct = default)
    {
        var query = Context.Set<Session>().AsQueryable();

        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var session = await query
            .Where(x => x.Phone == phone && !x.IsUsed && x.ExpiresAt > clock.Now)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync(ct);

        return session;
    }
    
    public async Task<Session> FindActiveAsync(
        Guid id,
        bool trackingEnabled = true,
        CancellationToken ct = default)
    {
        var query = Context.Set<Session>().AsQueryable();

        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var session = await query
            .FirstOrDefaultAsync(x => 
                x.Id == id && !x.IsUsed && x.ExpiresAt > clock.Now, ct);

        return session;
    }
}