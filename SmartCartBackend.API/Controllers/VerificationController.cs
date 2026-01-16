using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCardBackend.Application.Services.Verifications;
using SmartCartBackend.API.Requests;

namespace SmartCartBackend.API.Controllers;

[ApiController]
[Route("api/verification")]
public class VerificationController(
    IPhoneVerificationService verificationService) : ControllerBase
{
    [HttpPost("send-code")]
    [ProducesResponseType(typeof(VerificationResult), StatusCodes.Status200OK)]
    public async Task<IResult> SendVerificationCodeAsync(
        [FromBody] SendVerificationCodeRequest request)
    {
        var result = await verificationService.SendVerificationCodeAsync(
            request.Phone, HttpContext.RequestAborted);
        
        return Results.Ok(result);
    }
    
    [HttpPost("verify-code")]
    [ProducesResponseType(typeof(VerificationResult), StatusCodes.Status200OK)]
    public async Task<IResult> VerifyCodeAsync([FromBody] VerifyCodeRequest request)
    {
        var result = await verificationService.VerifyCodeAsync(
            request.Phone, request.Code, HttpContext.RequestAborted);
        
        return Results.Ok(result);
    }
}