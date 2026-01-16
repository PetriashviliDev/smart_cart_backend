namespace SmartCartBackend.Common.Clock;

public interface ISystemClock
{
    DateTimeOffset Now { get; }
}