namespace SmartCardBackend.Application.Options;

public record VectorSearchOptions
{
    public int Batch { get; set; }

    public double SimilarityThreshold { get; set; }

    public string Algorithm { get; set; }
}