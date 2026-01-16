using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace SmartCardBackend.Application.Services.Embedding;

public class EmbeddingService(
    HttpClient client,
    JsonSerializerSettings jsonSerializerSettings) : IEmbeddingService
{
    public async Task<EmbedResult> EmbedAsync(
        EmbedRequest request, 
        CancellationToken ct = default)
    {
        var json = JsonConvert.SerializeObject(request, jsonSerializerSettings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("/embed", content, ct);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(ct);
            throw new HttpRequestException($"{response.StatusCode}. {errorContent}");
        }
            
        var result = await response.Content.ReadFromJsonAsync<EmbedResult>(ct);
        return result;
    }
}