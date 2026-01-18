namespace SmartCardBackend.Application.Services.Embedding;

public record EmbedResult(string Model, int Dimensions, float[][] Embeddings);