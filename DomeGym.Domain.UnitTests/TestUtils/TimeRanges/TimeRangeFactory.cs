namespace DomeGym.Domain.UnitTests.TestUtils.TimeRanges;

public static class TimeRangeFactory 
{
    public static TimeRange CreateFromHours(int start, int end)
    {
        return new TimeRange(
            TimeOnly.MinValue.AddHours(start),
            TimeOnly.MinValue.AddHours(end));
    }
}