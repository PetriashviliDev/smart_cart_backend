using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.CQRS.Mediatr.Command.NutritionPlan.AcceptPlan;
using SmartCardBackend.Application.CQRS.Mediatr.Query.Nutrition.GetPlansByUser;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Nutrition.Pipeline;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Domain;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/nutrition-plan")]
[Authorize]
public class NutritionPlanController(
    IIdentityService identityService,
    ISender sender,
    INutritionPlanGenerationPipeline pipeline) 
    : ControllerBase
{
    /// <summary>
    /// Генерация плана питания
    /// </summary>
    /// <param name="requirements">Требования пользователя</param>
    /// <returns>Сгенерированный план</returns>
    [HttpPost("generate")]
    [ProducesResponseType(typeof(NutritionPlanResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GenerateAsync(
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
    /// Сохранение подтвержденного плана питания
    /// </summary>
    /// <param name="acceptedPlan">Подтвержденный план</param>
    [HttpPost("accept")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IResult> AcceptAsync(
        [FromBody] AcceptedNutritionPlanDto acceptedPlan)
    {
        var user = await identityService.GetUserContextAsync(
            HttpContext.RequestAborted);

        var command = new AcceptPlanCommand(user, acceptedPlan);
        await sender.Send(command, HttpContext.RequestAborted);
        
        return Results.Created();
    }

    /// <summary>
    /// Получение существующих планов питания пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="page">Номер страницы</param>
    /// <param name="size">Количество элементов на странице</param>
    [HttpGet("all/{userId:guid}")]
    [ProducesResponseType(typeof(PageResponse<NutritionPlanResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetByUserAsync(
        [FromRoute] Guid userId,
        [FromQuery] int page = 1,
        [FromQuery] int size = 30)
    {
        var query = new GetPlansByUserQuery(userId, page, size);
        var result = await sender.Send(query, HttpContext.RequestAborted);
        
        return Results.Ok(result.Value);
    }
}