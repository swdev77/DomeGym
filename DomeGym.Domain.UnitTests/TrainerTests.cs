using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using DomeGym.Domain.UnitTests.TestUtils.TimeRanges;
using DomeGym.Domain.UnitTests.TestUtils.Trainers;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;
public class TrainerTests 
{
    [Fact]
    public void AddSessionToSchedule_WhenSessionOverlapsWithAnotherSession_ShouldFail()
    {
        // Given
        var trainer = TrainerFactory.CreateTrainer();

        var session1 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(1, 2),
            id: Guid.NewGuid());
    
        var session2 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(1, 2),
            id: Guid.NewGuid());
    
        // When
        var result1 = trainer.AddSessionToSchedule(session1);
        var result2 = trainer.AddSessionToSchedule(session2);
    
        // Then
        result1.IsError.Should().BeFalse();

        result2.IsError.Should().BeTrue();
        result2.FirstError.Should().Be(TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions);
    }
}