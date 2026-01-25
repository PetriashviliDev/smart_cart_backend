using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/cart")]
[Authorize]
public class CartController : ControllerBase
{
    [HttpPost("save")]
    public Task<IResult> SaveCartAsync()
    {
        return Task.FromResult(Results.Ok());
    }
}