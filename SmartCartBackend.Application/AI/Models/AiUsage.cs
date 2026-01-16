using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SmartCardBackend.Application.AI.Models;

public record AiUsage
{
    [JsonProperty("prompt_tokens")]
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }
    
    [JsonProperty("completion_tokens")]
    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }
    
    [JsonProperty("total_tokens")]
    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}