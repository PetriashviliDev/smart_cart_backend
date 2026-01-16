namespace SmartCardBackend.Application.AI.Models;

public record AiResponse
{
    public List<AiChoice> Choices { get; set; }

    public AiUsage Usage { get; set; }
}