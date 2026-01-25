using SmartCardBackend.Domain.Repositories;

namespace SmartCardBackend.Domain;

public interface IUnitOfWork
{
    IIngredientRepository IngredientRepository { get; }
    
    IUserRepository UserRepository { get; }
    
    IPhoneVerificationRepository PhoneVerificationRepository { get; }
    
    ISessionRepository SessionRepository { get; }
    
    IUserAiRequestRepository UserAiRequestRepository { get; }
    
    IDishRepository DishRepository { get; }
    
    INutritionPlanDraftRepository NutritionPlanDraftRepository { get; }
    
    INutritionPlanRepository NutritionPlanRepository { get; }
    
    INutritionPlanChoiceRepository NutritionPlanChoiceRepository { get; }
    
    Task<bool> SaveChangesAsync(
        CancellationToken ct = default);
    
    Task<bool> TryBeginTransactionAsync(
        CancellationToken ct = default);
    
    Task<bool> TryRollbackTransactionAsync(
        CancellationToken ct = default);
    
    Task<bool> TryCommitTransactionAsync(
        CancellationToken ct = default);
}