using MediatR;
using SmartCardBackend.Application.ResultResponseHelper;

namespace SmartCardBackend.Application.Mediatr.Command;

public interface ICommand : IRequest<ResultResponseHelper.Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;