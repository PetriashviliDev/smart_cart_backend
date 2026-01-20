using System.Security.Claims;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using SmartCardBackend.Application.Constants;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Services.Identity;

public class IdentityService(
    IMapper mapper,
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
        
        return mapper.Map<UserContext>(user);
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