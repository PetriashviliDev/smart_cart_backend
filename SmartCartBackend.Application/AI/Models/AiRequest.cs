namespace SmartCardBackend.Application.AI.Models;

public class AiRequest
{
    public string Model { get; set; }
    
    public List<AiMessage> Messages { get; set; } = [];

    //public int MaxTokens { get; set; } = 5000;

    public bool Stream { get; set; } = false;
}