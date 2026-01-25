using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель рациона
/// </summary>
public class NutritionPlan : Entity<Guid>
{
    #region Constructors

    private NutritionPlan(Guid id) : base(id) { }
    
    [JsonConstructor]
    protected NutritionPlan(
        Guid id,
        Guid userId,
        User user,
        Guid draftId,
        NutritionPlanDraft draft,
        DateTimeOffset createdDate) 
        : base(id)
    {
        UserId = userId;
        User = user;
        DraftId = draftId;
        Draft = draft;
        CreatedDate = createdDate;
    }
    
    private NutritionPlan(
        Guid id,
        Guid userId,
        Guid draftId,
        DateTimeOffset createdDate) 
        : base(id)
    {
        UserId = userId;
        DraftId = draftId;
        CreatedDate = createdDate;
    }

    public static NutritionPlan Create(
        Guid id,
        Guid userId,
        Guid draftId,
        DateTimeOffset createdDate)
    {
        var plan = new NutritionPlan(
            id, userId, draftId, createdDate);
        
        return plan;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    /// <summary>
    /// Предложенный рацион
    /// </summary>
    public Guid DraftId { get; private set; }
    public NutritionPlanDraft Draft { get; private set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedDate { get; private set; }
    
    #endregion Properties
}