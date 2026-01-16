namespace SmartCardBackend.Application.Services.Embedding;

public interface IEmbeddingService
{
    Task<EmbedResult> EmbedAsync(
        EmbedRequest request, 
        CancellationToken cancellationToken = default);
}