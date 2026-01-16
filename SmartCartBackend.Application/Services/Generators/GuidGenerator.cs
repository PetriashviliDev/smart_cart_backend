namespace SmartCardBackend.Application.Services.Generators;

public class GuidGenerator : IGuidGenerator
{
    public Guid NewGuid => Guid.NewGuid();
}