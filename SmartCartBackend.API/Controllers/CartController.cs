using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCartBackend.API.Requests;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/cart")]
[Authorize]
public class CartController : ControllerBase
{
    [HttpPost("{cartId:guid}/invite")]
    public Task<IResult> InviteAsync(
        [FromRoute] Guid cartId, 
        [FromBody] InviteUserRequest request)
    {
        return Task.FromResult(Results.Ok());
    }
}