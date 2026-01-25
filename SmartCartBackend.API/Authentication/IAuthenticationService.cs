using SmartCardBackend.Application.ResultResponseHelper;
using SmartCartBackend.API.Requests;

namespace SmartCartBackend.API.Authentication;

public interface IAuthenticationService
{
    Task<Result<AuthenticationResponse>> RegisterUserAsync(
        RegisterUserRequest request, 
        CancellationToken ct = default);
    
    Task<Result<AuthenticationResponse>> RefreshTokenAsync(
        RefreshTokenRequest request, 
        CancellationToken ct = default);
    
    Task<Result<AuthenticationResponse>> LoginUserAsync(
        LoginUserRequest request, 
        CancellationToken ct = default);
}