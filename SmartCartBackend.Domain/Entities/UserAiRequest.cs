using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserAiRequest : Entity<Guid>
{
    #region Constructors
    
    private UserAiRequest(Guid id) : base(id) { }
    
    [JsonConstructor]
    protected UserAiRequest(
        Guid id, 
        Guid userId, 
        User user,
        string provider, 
        string model, 
        DateTimeOffset requestedAt,
        long durationMs,
        string status, 
        string errorText, 
        int? promptTokens, 
        int? completionTokens, 
        int? totalTokens) : base(id)
    {
        UserId = userId;
        User = user;
        Provider = provider;
        Model = model;
        RequestedAt = requestedAt;
        DurationMs = durationMs;
        Status = status;
        ErrorText = errorText;
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
        TotalTokens = totalTokens;
    }
    
    private UserAiRequest(
        Guid id, 
        Guid userId, 
        string provider, 
        string model, 
        DateTimeOffset requestedAt,
        long durationMs,
        string status, 
        string errorText, 
        int? promptTokens, 
        int? completionTokens, 
        int? totalTokens) : base(id)
    {
        UserId = userId;
        Provider = provider;
        Model = model;
        RequestedAt = requestedAt;
        DurationMs = durationMs;
        Status = status;
        ErrorText = errorText;
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
        TotalTokens = totalTokens;
    }

    public static UserAiRequest Create(
        Guid id,
        Guid userId,
        string provider, 
        string model, 
        DateTimeOffset requestedAt,
        long durationMs,
        string status, 
        string errorText = null, 
        int? promptTokens = null, 
        int? completionTokens = null, 
        int? totalTokens = null)
    {
        var history = new UserAiRequest(
            id, 
            userId, 
            provider, 
            model, 
            requestedAt,
            durationMs, 
            status, 
            errorText, 
            promptTokens, 
            completionTokens, 
            totalTokens);
        
        return history;
    }
    
    #endregion Constructors
    
    #region Properties

    public Guid UserId { get; private set; }

    public User User { get; }

    public string Provider { get; private set; }
    
    public string Model { get; private set; }
    
    public DateTimeOffset RequestedAt { get; private set; }

    public long DurationMs { get; set; }
    
    public string Status { get; private set; }
    
    public string ErrorText { get; private set; }
    
    public int? PromptTokens { get; private set; }
    
    public int? CompletionTokens { get; private set; }
    
    public int? TotalTokens { get; private set; }

    #endregion Properties
}