namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly int MaxParticipants = 1;
        public static readonly DateOnly Date = new(2023, 11, 1);
        public static readonly TimeOnly StartTime = new(10, 0);
        public static readonly TimeOnly EndTime = new(11, 0);
    }
}