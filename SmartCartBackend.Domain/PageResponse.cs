namespace SmartCardBackend.Domain;

public sealed record PageResponse<T>(
    IReadOnlyList<T> Items,
    int Page,
    int Size,
    int Total
)
{
    public static PageResponse<T> Default => new([], 1, 0, 0);
}