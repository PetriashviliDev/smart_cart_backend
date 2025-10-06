using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserIntolerance : Entity<Guid>
{
    #region Constructors
    
    [JsonConstructor]
    protected UserIntolerance(
        Guid id, 
        Guid userId,
        User user,
        int intoleranceId, 
        Intolerance intolerance) : base(id)
    {
        UserId = userId;
        User = user;
        IntoleranceId = intoleranceId;
        Intolerance = intolerance;
    }

    private UserIntolerance(
        Guid id,
        Guid userId,
        int intoleranceId) : base(id)
    {
        UserId = userId;
        IntoleranceId = intoleranceId;
    }

    public static UserIntolerance Create(
        Guid id,
        Guid userId,
        int intoleranceId)
    {
        var userIntolerance = new UserIntolerance(
            id, userId, intoleranceId);

        return userIntolerance;
    }
    
    #endregion Constructors

    #region Properties
    
    public Guid UserId { get; private set; }

    public User User { get; }

    public int IntoleranceId { get; private set; }

    public Intolerance Intolerance { get; }
    
    #endregion Properties
}