using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class PhoneVerification : Entity<Guid>
{
    #region Constructors
    
    [JsonConstructor]
    protected PhoneVerification(
        Guid id, 
        string phone, 
        string code,
        DateTime createdAt,
        DateTime expiresAt) : base(id)
    {
        Phone = phone;
        Code = code;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }

    public static PhoneVerification Create(
        Guid id,
        string phone,
        string code,
        DateTime createdAt,
        DateTime expiresAt)
    {
        var phoneVerification = new PhoneVerification(
            id, phone, code, createdAt, expiresAt);
        
        return phoneVerification;
    }
    
    #endregion Constructors
    
    #region Properties
    
    public string Phone { get; private set; }
    
    public string Code { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime ExpiresAt { get; private set; }

    public bool IsConfirmed { get; private set; }

    public DateTime? ConfirmedAt { get; private set; }
    
    #endregion Properties

    public void SetIsConfirmed(bool isConfirmed, DateTime confirmedAt)
    {
        IsConfirmed = isConfirmed;
        ConfirmedAt = confirmedAt;
    }
}