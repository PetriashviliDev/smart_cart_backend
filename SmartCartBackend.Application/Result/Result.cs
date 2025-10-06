using Microsoft.AspNetCore.Http;

namespace SmartCardBackend.Application.Result;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error.Type != ErrorType.None || !isSuccess &&  error.Type != ErrorType.None)
            throw new ArgumentException("Invalid error", nameof(error));
        
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    
    public T Match<T>(Func<T> onSuccess, Func<Error, T> onFailure) =>
        IsSuccess ? onSuccess() : onFailure(Error);
    
    public async Task<T> MatchAsync<T>(Func<Task<T>> onSuccess, Func<Error, T> onFailure) =>
        IsSuccess ? await onSuccess() : onFailure(Error);

    public IResult ToProblemDetails()
    {
        if (IsSuccess)
            throw new InvalidOperationException("The result is successful");

        return Results.Problem(
            statusCode: GetStatusCode(Error.Type),
            title: Error.Type.ToString(),
            extensions: new Dictionary<string, object>
            {
                { "errors", new[] { Error } }
            }!);
    }

    private static int GetStatusCode(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            ErrorType.None => StatusCodes.Status200OK,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };
}

public class Result<TValue> : Result
{
    private readonly TValue _value;
    
    protected internal Result(TValue value, bool isSuccess, Error error) 
        : base(isSuccess, error) => _value = value;
    
    public TValue Value => IsSuccess 
        ? _value 
        : throw new InvalidOperationException("The value of a failure can't be accessed");
    
    public static implicit operator Result<TValue>(TValue value) => 
        value != null ? Success(value) : Failure<TValue>(Error.None);
}