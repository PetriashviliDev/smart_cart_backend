namespace SmartCardBackend.Application.Services.Generators;

public interface IGuidGenerator
{
    Guid NewGuid { get; }
}