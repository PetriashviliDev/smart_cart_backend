namespace SmartCardBackend.Application.Dto;

public record EntityListResponse<TEntity>(List<TEntity> Entities, int Total);

public record EntityListResponse(List<object> Entities, int Total);