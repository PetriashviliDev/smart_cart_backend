using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Domain.Repositories;

public interface IPhoneVerificationRepository : IRepository<PhoneVerification, Guid>
{
    Task<PhoneVerification> FindLastIsNotConfirmedAsync(
        string phone,
        bool trackingEnabled = true,
        CancellationToken ct = default);
    
    Task<int> GetRecentCountAsync(
        string phone, 
        TimeSpan period, 
        CancellationToken ct = default);
}