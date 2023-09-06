namespace TestUp.Domain.Constans;

public static class Time
{
    public static DateTime GetCurrentTime()
    {
        var currentTime = DateTime.UtcNow.AddHours(5);
        return currentTime;
    }

    public static DateTime GetCurrentTime(int UTC)
    {
        var currentTime = DateTime.UtcNow.AddHours(UTC);
        return currentTime;
    }
}
