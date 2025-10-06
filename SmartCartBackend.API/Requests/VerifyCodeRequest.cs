namespace SmartCartBackend.API.Requests;

public record VerifyCodeRequest
{
    public string Phone { get; init; }
    
    public string Code { get; init; }
}