namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public const int MaxParticipants = 1;
        public static readonly DateOnly Date = DateOnly.FromDateTime(DateTime.Today);
        public static readonly TimeRange TimeRange = new (TimeOnly.MinValue.AddHours(1), TimeOnly.MinValue.AddHours(2));
    }
}