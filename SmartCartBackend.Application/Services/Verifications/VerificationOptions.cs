namespace SmartCardBackend.Application.Services.Verifications;

public record VerificationOptions
{
    public int VerificationTokenExpiryInMinutes { get; init; }
    
    public int CodeExpiryInMinutes { get; init; }
    
    public int SessionExpiryInMinutes { get; init; }

    public int MaxResentCodeCount { get; init; }
    
    public int MaxCodesPerHour { get; init; }
}