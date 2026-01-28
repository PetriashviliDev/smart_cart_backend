using MediatR;
using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.CQRS.Mediatr.Query;

public interface IQueryHandler<in TQuery> 
    : IRequestHandler<TQuery, Result>
    where TQuery : IQuery;
    
public interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;