using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Rooms;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using DomeGym.Domain.UnitTests.TestUtils.TimeRanges;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;
public class RoomTests 
{
    [Fact]
    public void ScheduleSession_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        var room = RoomFactory.CreateRoom(maxDailySessions: 1);

        var session1 = SessionFactory.CreateSession(id: Guid.NewGuid());
        var session2 = SessionFactory.CreateSession(id: Guid.NewGuid());

        var scheduleSession1Result = room.ScheduleSession(session1);
        var scheduleSession2Result = room.ScheduleSession(session2);

        scheduleSession1Result.IsError.Should().BeFalse();
        scheduleSession2Result.IsError.Should().BeTrue();
        scheduleSession2Result.FirstError.Should().Be(RoomErrors.CannotHaveMoreSessionsThanSubscriptionAllows);
    }

    [Theory]
    [InlineData(1,3,2,4)]
    [InlineData(2,3,1,4)]
    [InlineData(2,4,3,4)]
    [InlineData(1,4,2,3)]
    public void ScheduleSession_WhenSessionOverlapsWithAnotherSession_ShouldFail(
        int start,
        int end,
        int otherStart, 
        int otherEnd
    )
    {
        var room = RoomFactory.CreateRoom(maxDailySessions: 2);

        var session1 = SessionFactory.CreateSession(
            id: Guid.NewGuid(), 
            date: Constants.Session.Date, 
            time: TimeRangeFactory.CreateFromHours(start,end));

        var session2 = SessionFactory.CreateSession(
            id: Guid.NewGuid(), 
            date: Constants.Session.Date, 
            time: TimeRangeFactory.CreateFromHours(otherStart,otherEnd));

        var scheduleSession1Result = room.ScheduleSession(session1);
        var scheduleSession2Result = room.ScheduleSession(session2);

        scheduleSession1Result.IsError.Should().BeFalse();

        scheduleSession2Result.IsError.Should().BeTrue();
    }
}