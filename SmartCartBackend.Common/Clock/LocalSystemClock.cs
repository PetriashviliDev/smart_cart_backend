namespace SmartCartBackend.Common.Clock;

public class LocalSystemClock : ISystemClock
{
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}