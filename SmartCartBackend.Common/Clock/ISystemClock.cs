namespace SmartCartBackend.Common.Clock;

public interface ISystemClock
{
    DateTime Now { get; }
}