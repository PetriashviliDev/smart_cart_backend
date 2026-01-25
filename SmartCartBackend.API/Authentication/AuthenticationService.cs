using System.Security.Claims;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartCardBackend.Application.ResultResponseHelper;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Application.Services.Token.Access;
using SmartCardBackend.Application.Services.Token.Refresh;
using SmartCardBackend.Application.Services.Token.Verification;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.API.Requests;
using SmartCartBackend.Common.Clock;

namespace SmartCartBackend.API.Authentication;

public class AuthenticationService(
    ILogger<AuthenticationService> logger,
    IMapper mapper,
    IIdentityService identityService,
    IUnitOfWork unitOfWork,
    IAccessTokenManager accessTokenManager,
    IRefreshTokenManager refreshTokenManager,
    IVerificationTokenManager verificationTokenManager,
    IGuidGenerator guidGenerator, 
    ISystemClock clock) 
    : IAuthenticationService
{
    public async Task<Result<AuthenticationResponse>> RegisterUserAsync(
        RegisterUserRequest request, 
        CancellationToken ct = default)
    {
        var varificationToken = verificationTokenManager.ParseToken(identityService.GetToken());
        var claims = varificationToken.Claims.ToDto();

        var session = await unitOfWork.SessionRepository.FindActiveAsync(claims.SessionId, ct: ct);
        if (session == null)
            return Result.Failure<AuthenticationResponse>(
                Error.Unauthorized("Сессия не найдена или уже использована"));
        
        session.MarkAsUsed(isUsed: true, clock.Now);
        
        var user = await unitOfWork.UserRepository
            .SingleOrDefaultAsync(
                u => EF.Functions.ILike(u.Phone, claims.Phone), 
                trackingEnabled: false, 
                ct);

        if (user != null)
            return Result.Failure<AuthenticationResponse>(
                Error.Conflict("Пользователь с таким телефоном уже существует"));
        
        user = await unitOfWork.UserRepository
            .SingleOrDefaultAsync(
                u => EF.Functions.ILike(u.Email, request.Email), 
                trackingEnabled: false, 
                ct);
        
        if (user != null)
            return Result.Failure<AuthenticationResponse>(
                Error.Conflict("Пользователь с такой почтой уже существует"));

        var userId = guidGenerator.NewGuid;

        var userAllergies = request.Allergies
            .Select(a => UserAllergy.Create(guidGenerator.NewGuid, userId, a.Id))
            .ToList();

        var preferences = request.PreferenceDishes
            .Select(p => UserPreference.Create(guidGenerator.NewGuid, userId, p.Id))
            .ToList();
        
        user = User.Create(
            userId, 
            request.Name, 
            request.Email, 
            claims.Phone, 
            request.Gender, 
            request.Age, 
            request.Height, 
            request.Weight,
            request.ExcludedProducts,
            userAllergies,
            preferences,
            request.ActivityLevel.Id);
        
        unitOfWork.UserRepository.Add(user);
        
        var tokens = GenerateTokensAsync(user);
        
        await unitOfWork.SaveChangesAsync(ct);
        
        return tokens;
    }

    public async Task<Result<AuthenticationResponse>> RefreshTokenAsync(
        RefreshTokenRequest request, 
        CancellationToken ct = default)
    {
        var principal = accessTokenManager.Validate(
            request.AccessToken, validateLifetime: false, out _);
        
        if (!Guid.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
        {
            logger.LogError("Principal user identifier not found");
            return Result.Failure<AuthenticationResponse>(
                Error.Unauthorized("Ошибка аутентификации. Повторите попытку позже"));
        }

        var user = await unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Id == userId, ct: ct);
        if (user == null)
        {
            logger.LogError($"Database user {userId} not found");
            return Result.Failure<AuthenticationResponse>(
                Error.Unauthorized("Ошибка аутентификации. Повторите попытку позже"));
        }

        if (user.RefreshTokenHash != refreshTokenManager.HashToken(request.RefreshToken) ||
            user.RefreshTokenExpiry < clock.Now)
        {
            logger.LogError($"Invalid refresh token. User identifier: {userId}");
            return Result.Failure<AuthenticationResponse>(
                Error.Unauthorized("Ошибка аутентификации. Повторите попытку позже"));
        }

        var tokens = GenerateTokensAsync(user);
        
        await unitOfWork.SaveChangesAsync(ct);
        
        return tokens;
    }

    public async Task<Result<AuthenticationResponse>> LoginUserAsync(
        LoginUserRequest request, 
        CancellationToken ct = default)
    {
        var user = await unitOfWork.UserRepository
            .SingleOrDefaultAsync(u => EF.Functions.ILike(u.Phone, request.Phone), ct: ct);

        if (user == null)
        {
            logger.LogError($"Database user not found. Phone: {request.Phone}");
            return Result.Failure<AuthenticationResponse>(
                Error.Unauthorized("Ошибка аутентификации. Повторите попытку позже"));
        }

        var tokens = GenerateTokensAsync(user);
        
        await unitOfWork.SaveChangesAsync(ct);
        
        return tokens;
    }

    private AuthenticationResponse GenerateTokensAsync(User user)
    {
        var accessToken = accessTokenManager.Generate(user);
        var refreshToken = refreshTokenManager.Generate();

        var hash = refreshTokenManager.HashToken(refreshToken.Token);
        user.SetRefreshToken(hash, refreshToken.ExpiresAt);
        
        return new AuthenticationResponse
        {
            AccessToken = accessToken.Token,
            AccessTokenExpiresAt = accessToken.ExpiresAt,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresAt = refreshToken.ExpiresAt,
            User = mapper.Map<UserContext>(user)
        };
    }
}