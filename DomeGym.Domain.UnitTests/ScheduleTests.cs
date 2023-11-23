using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.TimeRanges;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class ScheduleTests
{
    [Fact]
    public void BookTimeSlot_WhenTimeAlreadyBooked_ShouldFail()
    {
        var schedule = new Schedule();

        TimeRange time = TimeRangeFactory.CreateFromHours(1,2);

        var bookTimeSlot1Result = schedule.BookTimeSlot(
            date: Constants.Session.Date,
            time: time);
        
        var bookTimeSlot2Result = schedule.BookTimeSlot(
            date: Constants.Session.Date,
            time: time);

        bookTimeSlot1Result.IsError.Should().BeFalse();
        bookTimeSlot2Result.IsError.Should().BeTrue();
    }
}           