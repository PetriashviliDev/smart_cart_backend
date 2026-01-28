using Microsoft.EntityFrameworkCore;

namespace SmartCardBackend.Domain.Extensions;

public static class CollectionExtensions
{
    public static async Task<PageResponse<T>> ToPageAsync<T>(
        this IQueryable<T> query,
        int page,
        int count,
        CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (count < 1) count = 1;

        var total = await query.CountAsync(ct);

        var items = await query
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync(ct);

        return new PageResponse<T>(
            items,
            page,
            count,
            total
        );
    }
}