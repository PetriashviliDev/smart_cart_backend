namespace SmartCardBackend.Application.Services.Verifications;

public interface IPhoneVerificationService
{
    Task<VerificationResult> SendVerificationCodeAsync(
        string phone, 
        CancellationToken ct = default);
    
    Task<VerificationResult> VerifyCodeAsync(
        string phone, 
        string code, 
        CancellationToken ct = default);
    
    Task<bool> CanSendCodeAsync(
        string phone, 
        CancellationToken ct = default);
}