namespace SmartCardBackend.Application.Verifications;

public record VerificationResult
{
    public bool Success { get; init; }
    
    public string Message { get; init; }
    
    public string Token { get; init; }
}