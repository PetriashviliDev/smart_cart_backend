using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Nutrition.Pipeline;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/nutrition")]
[Authorize]
public class NutritionController(
    IIdentityService identityService,
    INutritionPlanGenerationPipeline pipeline) 
    : ControllerBase
{
    [HttpPost("generate-plan")]
    [ProducesResponseType(typeof(NutritionPlanDto), StatusCodes.Status200OK)]
    public async Task<IResult> GeneratePlanAsync(
        [FromBody] NutritionRequirements requirements)
    {
        var user = await identityService.GetUserContextAsync(HttpContext.RequestAborted);

        var request = new NutritionPlanGenerationRequest
        {
            User = user,
            Requirements = requirements
        };
        
        var plan = await pipeline.GenerateAsync(request, HttpContext.RequestAborted);
        
        return Results.Ok(plan);
    }
    
    // TODO: создать command
    [HttpPost("accept-plan")]
    [ProducesResponseType(typeof(NutritionPlanDto), StatusCodes.Status200OK)]
    public async Task<IResult> AcceptPlanAsync(
        [FromBody] NutritionRequirements requirements)
    {
        var user = await identityService.GetUserContextAsync(HttpContext.RequestAborted);

        var request = new NutritionPlanGenerationRequest
        {
            User = user,
            Requirements = requirements
        };
        
        var plan = await pipeline.GenerateAsync(request, HttpContext.RequestAborted);
        
        return Results.Ok(plan);
    }
    
    // TODO: создать query
    [HttpPost("{dishId:int}/ingredients")]
    [ProducesResponseType(typeof(NutritionPlanDto), StatusCodes.Status200OK)]
    public async Task<IResult> GetIngredientsAsync([FromRoute] int dishId)
    {
        
        
        return Results.Ok();
    }
}