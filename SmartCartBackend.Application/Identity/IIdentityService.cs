namespace SmartCardBackend.Application.Identity;

public interface IIdentityService
{
    Task<UserContext> GetUserContextAsync(
        CancellationToken ct = default);
    
    string GetIpAddress();
    
    string GetUserAgent();

    string GetToken();
}