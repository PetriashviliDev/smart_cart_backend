using System.Linq.Expressions;

namespace SmartCardBackend.Domain;

public sealed record Sort<TSource>(
    Expression<Func<TSource, object>> KeySelector,
    SortDirection Direction = SortDirection.Asc
);