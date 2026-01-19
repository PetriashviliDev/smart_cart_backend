using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Http;
using SmartCardBackend.Application.Constants;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Services.Identity;

public class IdentityService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor contextAccessor) : IIdentityService
{
    public async Task<UserContext> GetUserContextAsync(
        CancellationToken ct = default)
    {
        var principal = contextAccessor.HttpContext!.User;

        var userId = Guid.Parse(principal.FindFirst(x => 
            x.Type == ClaimTypes.NameIdentifier)!.Value);
        
        var user = await unitOfWork.UserRepository
            .SingleOrDefaultAsync(
                x => x.Id == userId, 
                trackingEnabled: false, 
                ct);
        
        var userContext = user.Adapt<UserContext>();

        userContext.ActivityLevel = new Pair<int>
        {
            Id = user.ActivityLevel.Id, 
            Title = user.ActivityLevel.Title
        };
        
        userContext.Allergies = user.Allergies
            .Select(x => new Pair<int>
            {
                Id = x.Allergy.Id, 
                Title = x.Allergy.Title
            })
            .ToList();
        
        userContext.IpAddress = GetIpAddress();
        userContext.UserAgent = GetUserAgent();

        return userContext;
    }

    public string GetIpAddress() =>
        contextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";

    public string GetUserAgent() =>
        contextAccessor.HttpContext?.Request.Headers.UserAgent.ToString() ?? "unknown";

    public string GetToken()
    {
        var authorization = contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        var index = authorization.IndexOf($"{AuthConst.BearerScheme} ", StringComparison.OrdinalIgnoreCase);
        return authorization[(index + 7)..];
    }
}