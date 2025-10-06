using System.Diagnostics;

namespace SmartCardBackend.Application.Verifications;

public class SmsVerificationCodeSender : IVerificationCodeSender
{
    public Task<bool> SendAsync(
        string phone,
        string message,
        CancellationToken ct = default)
    {
        Debug.WriteLine($"Mock SMS to {phone}: {message}");
        return Task.FromResult(true);
    }
}