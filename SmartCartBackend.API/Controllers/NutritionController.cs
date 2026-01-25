using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Mediatr.Command.Nutrition.AcceptPlan;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Nutrition.Pipeline;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/nutrition")]
[Authorize]
public class NutritionController(
    IIdentityService identityService,
    ISender sender,
    INutritionPlanGenerationPipeline pipeline) 
    : ControllerBase
{
    /// <summary>
    /// Генерация плана
    /// </summary>
    /// <param name="requirements">Требования пользователя</param>
    /// <returns>Сгенерированный план</returns>
    [HttpPost("generate-plan")]
    [ProducesResponseType(typeof(NutritionPlanDto), StatusCodes.Status200OK)]
    public async Task<IResult> GeneratePlanAsync(
        [FromBody] NutritionRequirements requirements)
    {
        var user = await identityService.GetUserContextAsync(
            HttpContext.RequestAborted);

        var request = new NutritionPlanGenerationRequest
        {
            User = user,
            Requirements = requirements
        };
        
        var plan = await pipeline.GenerateAsync(
            request, HttpContext.RequestAborted);
        
        return Results.Ok(plan);
    }
    
    /// <summary>
    /// Сохранение подтвержденного плана
    /// </summary>
    /// <param name="acceptedPlan">Подтвержденный план</param>
    [HttpPost("accept-plan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> AcceptPlanAsync(
        [FromBody] AcceptedNutritionPlanDto acceptedPlan)
    {
        var user = await identityService.GetUserContextAsync(
            HttpContext.RequestAborted);

        var command = new AcceptPlanCommand(user, acceptedPlan);
        await sender.Send(command, HttpContext.RequestAborted);
        
        return Results.Created();
    }
}