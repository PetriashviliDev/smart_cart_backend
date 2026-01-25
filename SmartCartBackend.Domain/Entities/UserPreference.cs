using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserPreference : Entity<Guid>
{
    #region Constructors
    
    private UserPreference(Guid id) : base(id) { }
    
    [JsonConstructor]
    protected UserPreference(
        Guid id, 
        Guid userId,
        int dishId, 
        Dish dish) : base(id)
    {
        UserId = userId;
        DishId = dishId;
        Dish = dish;
    }

    private UserPreference(
        Guid id,
        Guid userId,
        int dishId) : base(id)
    {
        UserId = userId;
        DishId = dishId;
    }

    public static UserPreference Create(
        Guid id,
        Guid userId,
        int dishId)
    {
        var userPreference = new UserPreference(
            id, userId, dishId);

        return userPreference;
    }
    
    #endregion Constructors

    #region Properties
    
    public Guid UserId { get; private set; }

    public User User { get; }

    public int DishId { get; private set; }

    public Dish Dish { get; }
    
    #endregion Properties
}