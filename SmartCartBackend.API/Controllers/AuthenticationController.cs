using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCartBackend.API.Authentication;
using SmartCartBackend.API.Requests;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(
    IAuthenticationService authService) : ControllerBase
{
    /// <summary>
    /// Регистрация пользователя после подтверждения мобильного телефона.
    /// Создание пары access_token и refresh_token
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    [HttpPost("register")]
    [Authorize]
    [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
    public async Task<IResult> RegisterUserAsync([FromBody] RegisterUserRequest request)
    {
        var result = await authService.RegisterUserAsync(request, HttpContext.RequestAborted);
        return result.Match(() => Results.Ok(result.Value), _ => result.ToProblemDetails());
    }
    
    /// <summary>
    /// Создание пары access_token и refresh_token после истечения срока годности обоих 
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
    public async Task<IResult> LoginUserAsync([FromBody] LoginUserRequest request)
    {
        var result = await authService.LoginUserAsync(request, HttpContext.RequestAborted);
        return result.Match(() => Results.Ok(result.Value), _ => result.ToProblemDetails());
    }
    
    /// <summary>
    /// Пересоздание access_token после истечения срока годности по актуальному refresh_token
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    [HttpPost("refresh")]
    [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
    public async Task<IResult> RefreshTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var result = await authService.RefreshTokenAsync(request, HttpContext.RequestAborted);
        return result.Match(() => Results.Ok(result.Value), _ => result.ToProblemDetails());
    }
}