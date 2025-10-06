namespace SmartCartBackend.Common.Clock;

public class LocalSystemClock : ISystemClock
{
    public DateTime Now => DateTime.Now;
}