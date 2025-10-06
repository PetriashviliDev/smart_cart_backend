namespace SmartCardBackend.Application.AI.Models;

public class AiRequest
{
    public string Model { get; set; }
    public List<AiMessage> Messages { get; set; }
}