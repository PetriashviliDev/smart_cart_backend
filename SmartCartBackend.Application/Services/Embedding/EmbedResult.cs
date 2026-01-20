using System.Text.Json.Serialization;

namespace SmartCardBackend.Application.Services.Embedding;

public record EmbedResult
{
    public string Model { get; set; }
    
    [JsonPropertyName("dim")]
    public int Dimensions { get; set; }
    
    public float[][] Embeddings { get; set; }
}