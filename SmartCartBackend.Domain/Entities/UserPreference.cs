using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserPreference : Entity<Guid>
{
    #region Constructors
    
    [JsonConstructor]
    protected UserPreference(
        Guid id, 
        Guid userId,
        int preferenceId, 
        Preference preference) : base(id)
    {
        UserId = userId;
        PreferenceId = preferenceId;
        Preference = preference;
    }

    private UserPreference(
        Guid id,
        Guid userId,
        int preferenceId) : base(id)
    {
        UserId = userId;
        PreferenceId = preferenceId;
    }

    public static UserPreference Create(
        Guid id,
        Guid userId,
        int preferenceId)
    {
        var userPreference = new UserPreference(
            id, userId, preferenceId);

        return userPreference;
    }
    
    #endregion Constructors

    #region Properties
    
    public Guid UserId { get; private set; }

    public User User { get; }

    public int PreferenceId { get; private set; }

    public Preference Preference { get; }
    
    #endregion Properties
}