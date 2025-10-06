using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class Session : Entity<Guid>
{
    #region Constructors
    
    [JsonConstructor]
    protected Session(
        Guid id,
        string phone,
        string ipAddress,
        string userAgent,
        DateTime createdAt,
        DateTime expiresAt,
        bool isUsed,
        DateTime? usedAt) : base(id) 
    {
        Phone = phone;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
        IsUsed = isUsed;
        UsedAt = usedAt;
    }

    public static Session Create(
        Guid id,
        string phone,
        string ipAddress,
        string userAgent,
        DateTime createdAt,
        DateTime expiresAt)
    {
        var session = new Session(id, phone, ipAddress, userAgent, 
            createdAt, expiresAt, isUsed: false, usedAt: null);

        return session;
    }
    
    #endregion Constructors
    
    #region Properties
    
    public string Phone { get; private set; }
    
    public string IpAddress { get; private set; }
    
    public string UserAgent { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime ExpiresAt { get; private set; }
    
    public bool IsUsed { get; private set; }
    
    public DateTime? UsedAt { get; private set; }
    
    #endregion Properties

    public void MarkAsUsed(bool isUsed, DateTime usedAt)
    {
        IsUsed = isUsed;
        UsedAt = usedAt;
    }
}