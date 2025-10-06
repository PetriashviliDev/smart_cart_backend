namespace SmartCardBackend.Application.Generators;

public class GuidGenerator : IGuidGenerator
{
    public Guid NewGuid => Guid.NewGuid();
}