using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SmartCardBackend.Application.AI.Clients;

public class OpenRouterAiClient(
    HttpClient client) : IAiClient
{
    public async Task<string> AskAsync(
        string prompt, 
        string systemPrompt = null, 
        CancellationToken ct = default)
    {
        var requestBody = new
        {
            model = "deepseek/deepseek-chat-v3.1:free",
            messages = new[]
            {
                new
                {
                    role = "Эксперт-нутрициолог с 20-летним опытом", 
                    content = "Составь дневной план рациона для мужчины 30 лет с тремя приемами пищи"
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(string.Empty, content, ct);
        //response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadFromJsonAsync<JsonElement>(ct);
        var answer = responseString.GetProperty("choices")[0].GetProperty("messages").GetProperty("content").GetString();

        return answer;
    }
}