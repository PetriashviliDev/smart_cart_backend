namespace SmartCardBackend.Application.Responses;

public record EntityListResponse<TEntity>(List<TEntity> Entities, int Total);

public record EntityListResponse(List<object> Entities, int Total);