namespace SmartCardBackend.Application.Dto;

public record Pair<TIdentifier>(TIdentifier Id, string Title);