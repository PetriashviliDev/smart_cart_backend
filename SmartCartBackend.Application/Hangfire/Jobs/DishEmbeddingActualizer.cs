using SmartCardBackend.Application.Extensions;
using SmartCardBackend.Application.Services.Embedding;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Application.Services.Helpers;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Hangfire.Jobs;

public class DishEmbeddingActualizer(
    ISystemClock clock,
    IGuidGenerator guidGenerator,
    IEmbeddingService embeddingService,
    IUnitOfWork uow) : IJob
{
    public async Task ExecuteAsync(CancellationToken ct)
    {
        var now = clock.Now;

        var dishes = await uow.DishRepository.FindManyAsync(_ => true, ct: ct);
        foreach (var dish in dishes)
        {
            var hash = HashHelper.ComputeSha256(dish.Description);

            if (dish.DishEmbedding == null)
            {
                var embeddingResult = await embeddingService.EmbedAsync(
                    new EmbedRequest(dish.Description), ct);

                var dishEmbedding = DishEmbedding.Create(
                    guidGenerator.NewGuid,
                    dish.Id,
                    embeddingResult.Model,
                    embeddingResult.Dimensions,
                    hash,
                    now,
                    embeddingResult.Embeddings.ToVector()
                );

                dish.SetEmbedding(dishEmbedding);
            }
            else if (!dish.DishEmbedding.ContentHash.EqualsIgnoreCase(hash))
            {
                var embeddingResult = await embeddingService.EmbedAsync(
                    new EmbedRequest(dish.Description), ct);

                dish.DishEmbedding.Update(
                    embeddingResult.Model,
                    embeddingResult.Dimensions,
                    hash,
                    now,
                    embeddingResult.Embeddings.ToVector()
                );
            }
        }

        await uow.SaveChangesAsync(ct);
    }
}