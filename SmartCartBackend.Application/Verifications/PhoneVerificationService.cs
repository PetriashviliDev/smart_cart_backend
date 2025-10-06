using Microsoft.Extensions.Options;
using SmartCardBackend.Application.Generators;
using SmartCardBackend.Application.Identity;
using SmartCardBackend.Application.Token.Verification;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Verifications;

public class PhoneVerificationService(
    IIdentityService  identityService,
    IVerificationTokenManager verificationTokenManager,
    IUnitOfWork unitOfWork,
    IGuidGenerator guidGenerator,
    ISystemClock clock,
    IOptions<VerificationOptions> options,
    IVerificationCodeSender verificationCodeSender) : IPhoneVerificationService
{
    private readonly VerificationOptions _verificationOptions = options.Value;
    
    public async Task<VerificationResult> SendVerificationCodeAsync(
        string phone, 
        CancellationToken ct = default)
    {
        if (!await CanSendCodeAsync(phone, ct))
        {
            return new VerificationResult
            {
                Success = false,
                Message = "Превышен лимит отправки кодов. Попробуйте позже"
            };
        }
        
        var code = GenerateRandomCode();
        
        var now = clock.Now;
        var codeExpiration = _verificationOptions.CodeExpiryInMinutes;
        var expiresAt = now.AddMinutes(codeExpiration); 

        var verification = PhoneVerification.Create(
            guidGenerator.NewGuid, 
            phone, 
            code,
            now,
            expiresAt);

        unitOfWork.PhoneVerificationRepository.Add(verification);
        
        var session = Session.Create(
            guidGenerator.NewGuid,
            phone,
            identityService.GetIpAddress(),
            identityService.GetUserAgent(),
            now,
            now.AddMinutes(_verificationOptions.SessionExpiryInMinutes));
        
        unitOfWork.SessionRepository.Add(session);

        await verificationCodeSender.SendAsync(
            phone, 
            $"Ваш код подтверждения: {code}. Действует {codeExpiration} мин.", 
            ct);
        
        await unitOfWork.SaveChangesAsync(ct);

        return new VerificationResult
        {
            Success = true,
            Message = "Код подтверждения отправлен"
        };
    }

    public async Task<VerificationResult> VerifyCodeAsync(
        string phone, 
        string code, 
        CancellationToken ct = default)
    {
        var verification = await unitOfWork.PhoneVerificationRepository
            .FindLastIsNotConfirmedAsync(phone, ct: ct);
        
        if (verification == null)
        {
            return new VerificationResult
            {
                Success = false,
                Message = "Код не найден или истек срок действия"
            };
        }

        if (verification.Code != code)
        {
            return new VerificationResult
            {
                Success = false,
                Message = "Неверный код подтверждения"
            };
        }
        
        var now = clock.Now;
        
        verification.SetIsConfirmed(isConfirmed: true, now);

        var session = await unitOfWork.SessionRepository.FindLastActiveAsync(
            phone, trackingEnabled: false, ct);
        
        if (session == null)
        {
            return new VerificationResult
            {
                Success = false,
                Message = "Не найдена активная сессия"
            };
        }
        
        var expirationPeriod = TimeSpan.FromMinutes(
            _verificationOptions.CodeExpiryInMinutes);
        
        var verificationTokenResult = verificationTokenManager
            .Generate(session, expirationPeriod);
        
        await unitOfWork.SaveChangesAsync(ct);

        return new VerificationResult
        {
            Success = true,
            Message = "Телефон успешно подтвержден",
            Token = verificationTokenResult.Token
        };
    }

    public async Task<bool> CanSendCodeAsync(
        string phone, 
        CancellationToken ct = default)
    {
        var period = TimeSpan.FromHours(_verificationOptions.MaxCodesPerHour);
        
        var recentCodes = await unitOfWork.PhoneVerificationRepository
            .GetRecentCountAsync(phone, period, ct);
        
        return recentCodes < _verificationOptions.MaxResentCodeCount;
    }
    
    private static string GenerateRandomCode()
    {
        var random = new Random();
        return random.Next(1000, 9999).ToString();
    }
}