namespace SmartCardBackend.Application.AI.Models;

public record AiMessage
{
    public string Role { get; set; }
    public string Content { get; set; }
}