namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Schedule
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly TimeOnly StartTime = TimeOnly.FromDateTime(DateTime.Today.AddHours(10));
        public static readonly TimeOnly EndTime = TimeOnly.FromDateTime(DateTime.Today.AddHours(11));
    }
}