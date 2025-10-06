using MediatR;
using SmartCardBackend.Application.Result;

namespace SmartCardBackend.Application.Mediatr.Command;

public interface ICommand : IRequest<Result.Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;