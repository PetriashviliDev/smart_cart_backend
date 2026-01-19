using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Services.Actualizers;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/system")]
[Authorize]
public class SystemController(
    IEnumerationActualizer enumerationActualizer) 
    : ControllerBase
{
    [HttpPatch("enumeration-reactualize")]
    public async Task<IResult> ReactualizeEnumerationAsync()
    {
        await enumerationActualizer.ActualizeAsync(
            HttpContext.RequestAborted);
        
        return Results.Ok();
    }
}