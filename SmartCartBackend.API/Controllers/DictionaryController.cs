using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Services.Queries;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/dictionary")]
[Authorize]
public class DictionaryController(
    IDictionaryQuery query) 
    : ControllerBase
{
    [HttpGet("types")]
    public async Task<IResult> GetDictionaryTypesAsync()
    {
        var types = await query.GetDictionaryTypesAsync(HttpContext.RequestAborted);
        return Results.Ok(types);
    }
    
    [HttpGet("{dictionaryName}")]
    public async Task<IResult> GetDictionaryAsync(string dictionaryName)
    {
        var dictionary = await query.GetDictionaryAsync(
            dictionaryName, HttpContext.RequestAborted);
        
        return Results.Ok(dictionary);
    }
}