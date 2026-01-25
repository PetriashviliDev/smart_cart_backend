using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель предложенного рациона
/// </summary>
public class NutritionPlanDraft : Entity<Guid>
{
    #region Constructors

    private NutritionPlanDraft(Guid id) : base(id) { }
    
    [JsonConstructor]
    protected NutritionPlanDraft(
        Guid id, 
        Guid userId,
        User user,
        string planJson,
        DateTimeOffset createdDate) 
        : base(id)
    {
        UserId = userId;
        User = user;
        PlanJson = planJson;
        CreatedDate = createdDate;
    }
    
    private NutritionPlanDraft(
        Guid id, 
        Guid userId,
        string planJson,
        DateTimeOffset createdDate) 
        : base(id)
    {
        UserId = userId;
        PlanJson = planJson;
        CreatedDate = createdDate;
    }

    public static NutritionPlanDraft Create(
        Guid id, 
        Guid userId,
        string planJson,
        DateTimeOffset createdDate)
    {
        var draft = new NutritionPlanDraft(
            id, userId, planJson, createdDate);
        
        return draft;
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
    public string PlanJson { get; private set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedDate { get; private set; }
    
    #endregion Properties
}