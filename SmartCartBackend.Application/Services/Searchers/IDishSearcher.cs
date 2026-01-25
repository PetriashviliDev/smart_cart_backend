using Pgvector;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Services.Searchers;

public interface IDishSearcher
{
    /// <summary>
    /// Семантический поиск подходящих блюд
    /// </summary>
    /// <param name="queryEmbedding">Векторное представление предпочтений пользователя</param>
    /// <param name="batch">Размер </param>
    /// <param name="similarityThreshold">Сходство. 1 - полное, 0 - никакое</param>
    /// <param name="ct">Токен отмены асинхронной операции</param>
    /// <returns>Список подходящих блюд</returns>
    Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding,
        int batch,
        double similarityThreshold,
        CancellationToken ct = default);
}