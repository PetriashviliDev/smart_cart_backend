using MediatR;
using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.CQRS.Mediatr.Command;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;