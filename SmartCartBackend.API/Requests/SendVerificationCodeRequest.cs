namespace SmartCartBackend.API.Requests;

public record SendVerificationCodeRequest
{
    public string Phone { get; init; }
}