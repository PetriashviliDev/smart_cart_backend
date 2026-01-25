namespace SmartCardBackend.Application.ResultResponseHelper;

public sealed class Error
{
    private Error(string description, ErrorType type)
    {
        Description = description;
        Type = type;
    }

    public string Description { get; }
    
    public ErrorType Type { get; }
    
    public static Error None => new(string.Empty, ErrorType.None);
    public static Error NullValue => new("Значение NULL", ErrorType.NullValue);
    
    public static Error NotFound(string description) => new(description, ErrorType.NotFound);
    public static Error ServerFailure(string description) => new(description, ErrorType.Failure);
    public static Error Unauthorized(string description) => new(description, ErrorType.Unauthorized);
    public static Error Forbidden(string description) => new(description, ErrorType.Forbidden);
    public static Error BadRequest(string description) => new(description, ErrorType.BadRequest);
    public static Error Conflict(string description) => new(description, ErrorType.Conflict);
    
    public static implicit operator ResultResponseHelper.Result(Error error) => ResultResponseHelper.Result.Failure(error);
    
    public ResultResponseHelper.Result ToResult() => ResultResponseHelper.Result.Failure(this);
}

public enum ErrorType
{
    Failure, 
    NotFound,
    BadRequest,
    Unauthorized,
    Forbidden,
    NullValue,
    Conflict,
    None
}