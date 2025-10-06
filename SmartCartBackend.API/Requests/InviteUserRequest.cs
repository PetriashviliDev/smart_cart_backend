namespace SmartCartBackend.API.Requests;

public record InviteUserRequest
{
    public string MobilePhone { get; init; }
}