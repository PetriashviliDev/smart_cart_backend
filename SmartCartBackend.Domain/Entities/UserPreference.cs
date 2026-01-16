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
        Dish dish, 
        int mealTypeId, 
        MealType mealType) : base(id)
    {
        UserId = userId;
        DishId = dishId;
        Dish = dish;
        MealTypeId = mealTypeId;
        MealType = mealType;
    }

    private UserPreference(
        Guid id,
        Guid userId,
        int dishId,
        int mealTypeId) : base(id)
    {
        UserId = userId;
        DishId = dishId;
        MealTypeId = mealTypeId;
    }

    public static UserPreference Create(
        Guid id,
        Guid userId,
        int dishId, 
        int mealTypeId)
    {
        var userPreference = new UserPreference(
            id, userId, dishId, mealTypeId);

        return userPreference;
    }
    
    #endregion Constructors

    #region Properties
    
    public Guid UserId { get; private set; }

    public User User { get; }

    public int DishId { get; private set; }

    public Dish Dish { get; }

    public int MealTypeId { get; private set; }

    public MealType MealType { get; }
    
    #endregion Properties
}