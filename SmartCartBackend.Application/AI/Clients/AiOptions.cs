namespace SmartCardBackend.Application.AI.Clients;

public record AiOptions
{
    public string BaseAddress { get; set; }
    public string ApiKey { get; set; }
    public string Model { get; set; }
    public int MaxTokens { get; set; }
}