using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserAllergy : Entity<Guid>
{
    #region Constructors

    private UserAllergy(Guid id) : base(id) { }

    [JsonConstructor]
    protected UserAllergy(
        Guid id, 
        Guid userId, 
        User user,
        int allergyId, 
        Allergy allergy) : base(id)
    {
        UserId = userId;
        User = user;
        AllergyId = allergyId;
        Allergy = allergy;
    }
    
    private UserAllergy(
        Guid id, 
        Guid userId, 
        int allergyId) : base(id)
    {
        UserId = userId;
        AllergyId = allergyId;
    }

    public static UserAllergy Create(
        Guid id,
        Guid userId,
        int allergyId)
    {
        var userAllergy = new UserAllergy(
            id, userId, allergyId);
        
        return userAllergy;
    }
    
    #endregion Constructors
    
    #region Properties

    public Guid UserId { get; private set; }

    public User User { get; }

    public int AllergyId { get; private set; }

    public Allergy Allergy { get; }
    
    #endregion Properties
}