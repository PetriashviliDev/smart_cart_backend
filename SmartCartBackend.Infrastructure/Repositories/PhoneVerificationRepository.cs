using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;
using SmartCartBackend.Common.Clock;

namespace SmartCartBackend.Infrastructure.Repositories;

public class PhoneVerificationRepository(
    ISystemClock clock,
    DatabaseContext context)
    : Repository<PhoneVerification, Guid>(context), IPhoneVerificationRepository
{
    public async Task<PhoneVerification> FindLastIsNotConfirmedAsync(
        string phone, 
        bool trackingEnabled = true,
        CancellationToken ct = default)
    {
        var query = Context.Set<PhoneVerification>().AsQueryable();

        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var lastVerification = await query
            .Where(x => x.Phone == phone && x.ExpiresAt >= clock.Now && !x.IsConfirmed)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync(ct);
        
        return lastVerification;
    }

    public async Task<int> GetRecentCountAsync(
        string phone, 
        TimeSpan period, 
        CancellationToken ct = default)
    {
        var query = Context.Set<PhoneVerification>().AsQueryable();
        
        var timeThreshold = clock.Now - period;
        
        var count = await query.CountAsync(x => x.Phone == phone && x.CreatedAt >= timeThreshold , ct);
        return count;
    }
}