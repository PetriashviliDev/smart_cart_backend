namespace SmartCardBackend.Application.Token;

public record TokenResponse
{
    public string Token { get; init; }
    
    public DateTime ExpiresAt { get; init; }
}