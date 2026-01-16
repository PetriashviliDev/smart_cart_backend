namespace SmartCardBackend.Application.Services.Verifications;

public interface IVerificationCodeSender
{
    Task<bool> SendAsync(
        string key,
        string message,
        CancellationToken ct = default);
}