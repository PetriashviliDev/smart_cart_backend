namespace SmartCardBackend.Application.Services.Embedding;

public interface IEmbeddingTextBuilder<in TEntity>
{
    string BuildFor(TEntity entity);
}