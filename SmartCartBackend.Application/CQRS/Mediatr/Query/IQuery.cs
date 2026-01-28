using MediatR;
using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.CQRS.Mediatr.Query;

public interface IQuery : IRequest<Result>;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;