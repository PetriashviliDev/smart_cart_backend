using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Application.Services.Queries;
using SmartCardBackend.Domain;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/dictionary")]
[Authorize]
public class DictionaryController(
    IDictionaryQuery query) 
    : ControllerBase
{
    /// <summary>
    /// Получение возможных типов справочников
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="size">Количество элементов на странице</param>
    [HttpGet("types")]
    [ProducesResponseType(typeof(PageResponse<string>), StatusCodes.Status200OK)]
    public IResult GetDictionaryTypes(
        [FromQuery] int page = 1, 
        [FromQuery] int size = 30)
    {
        var types = query.GetDictionaryTypes(page, size);
        return Results.Ok(types);
    }
    
    /// <summary>
    /// Получение значений конкретного справочника
    /// </summary>
    /// <param name="dictionaryName">Название типа справочника</param>
    /// <param name="page">Номер страницы</param>
    /// <param name="size">Количество элементов на странице</param>
    [HttpGet("{dictionaryName}")]
    [ProducesResponseType(typeof(PageResponse<Pair<int>>), StatusCodes.Status200OK)]
    public async Task<IResult> GetDictionaryAsync(
        [FromRoute] string dictionaryName,
        [FromQuery] int page = 1, 
        [FromQuery] int size = 30)
    {
        var dictionary = await query.GetDictionaryAsync(
            dictionaryName, page, size, HttpContext.RequestAborted);
        
        return Results.Ok(dictionary);
    }
}