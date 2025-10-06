using SmartCardBackend.Domain.Repositories;

namespace SmartCardBackend.Domain;

public interface IUnitOfWork
{
    IIngredientRepository IngredientRepository { get; }
    
    IUserRepository UserRepository { get; }
    
    IPhoneVerificationRepository PhoneVerificationRepository { get; }
    
    ISessionRepository SessionRepository { get; }
    
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
}