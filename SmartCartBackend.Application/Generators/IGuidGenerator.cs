namespace SmartCardBackend.Application.Generators;

public interface IGuidGenerator
{
    Guid NewGuid { get; }
}