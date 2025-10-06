namespace SmartCardBackend.Application.AI.Clients;

public interface IAiClient
{
    Task<string> AskAsync(
        string prompt, 
        string systemPrompt = null, 
        CancellationToken ct = default);
}