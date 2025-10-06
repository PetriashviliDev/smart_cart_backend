using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure;

public class UnitOfWork(
    DatabaseContext context,
    IIngredientRepository ingredientRepository,
    IUserRepository userRepository,
    IPhoneVerificationRepository phoneVerificationRepository,
    ISessionRepository sessionRepository) : IUnitOfWork
{
    public IIngredientRepository IngredientRepository { get; } = ingredientRepository;
    
    public IUserRepository UserRepository { get; } = userRepository;
    
    public IPhoneVerificationRepository PhoneVerificationRepository { get; } = phoneVerificationRepository;
    
    public ISessionRepository SessionRepository { get; } = sessionRepository;

    public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        // TODO: pre and post domain events
        var result = await context.SaveChangesAsync(ct);
        return result > 0;
    }
}