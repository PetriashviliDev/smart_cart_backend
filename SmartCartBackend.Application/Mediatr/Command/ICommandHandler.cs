using MediatR;
using SmartCardBackend.Application.Result;

namespace SmartCardBackend.Application.Mediatr.Command;

public interface ICommandHandler<in TCommand> 
    : IRequestHandler<TCommand, Result.Result>
    where TCommand : ICommand;
    
public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;