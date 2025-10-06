using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Identity;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Nutrition.Strategy;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/nutrition")]
[Authorize]
public class NutritionController(
    IIdentityService identityService,
    INutritionStrategy strategy) : ControllerBase
{
    [HttpPost("generate-plan")]
    [ProducesResponseType(typeof(NutritionPlan), StatusCodes.Status200OK)]
    public async Task<IResult> GeneratePlanAsync(
        [FromBody] NutritionRequirements requirements)
    {
        var user = await identityService.GetUserContextAsync(HttpContext.RequestAborted);
        var plan = await strategy.GeneratePlanAsync(user, requirements, HttpContext.RequestAborted);
        
        return Results.Ok(plan);
    }
}