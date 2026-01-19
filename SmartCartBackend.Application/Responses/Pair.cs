namespace SmartCardBackend.Application.Responses;

public record Pair<TIdentifier>
{
    public TIdentifier Id { get; set; }
    public string Title { get; set; }
}