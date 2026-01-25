using Microsoft.EntityFrameworkCore.Storage;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure;

public class UnitOfWork(
    IDatabaseContextFactory contextFactory,
    IIngredientRepository ingredientRepository,
    IUserRepository userRepository,
    IPhoneVerificationRepository phoneVerificationRepository,
    ISessionRepository sessionRepository, 
    IUserAiRequestRepository userAiRequestRepository, 
    IDishRepository dishRepository,
    INutritionPlanDraftRepository nutritionPlanDraftRepository,
    INutritionPlanRepository nutritionPlanRepository,
    INutritionPlanChoiceRepository nutritionPlanChoiceRepository) 
    : IUnitOfWork
{
    private IDbContextTransaction _transaction;

    public DatabaseContext Context => contextFactory.GetOrCreateDbContext();
    
    public IIngredientRepository IngredientRepository { get; } = ingredientRepository;
    
    public IUserRepository UserRepository { get; } = userRepository;
    
    public IPhoneVerificationRepository PhoneVerificationRepository { get; } = phoneVerificationRepository;
    
    public ISessionRepository SessionRepository { get; } = sessionRepository;
    
    public IUserAiRequestRepository UserAiRequestRepository { get; } = userAiRequestRepository;
    
    public IDishRepository DishRepository { get; } = dishRepository;
    
    public INutritionPlanDraftRepository NutritionPlanDraftRepository { get; } = nutritionPlanDraftRepository;
    
    public INutritionPlanRepository NutritionPlanRepository { get; } = nutritionPlanRepository;
    
    public INutritionPlanChoiceRepository NutritionPlanChoiceRepository { get; } = nutritionPlanChoiceRepository;

    public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        // TODO: pre and post domain events
        var result = await Context.SaveChangesAsync(ct);
        return result > 0;
    }

    public async Task<bool> TryBeginTransactionAsync(
        CancellationToken ct = default)
    {
        if (_transaction != null)
            return false;
        
        _transaction = await Context.Database.BeginTransactionAsync(ct);
        
        return true;
    }

    public async Task<bool> TryRollbackTransactionAsync(
        CancellationToken ct = default)
    {
        if (_transaction == null) 
            return false;
        
        await _transaction.RollbackAsync(ct);
        _transaction = null;

        return true;

    }

    public async Task<bool> TryCommitTransactionAsync(
        CancellationToken ct = default)
    {
        if (_transaction == null) 
            return false;
        
        await _transaction.CommitAsync(ct);
        _transaction = null;

        return true;
    }
}