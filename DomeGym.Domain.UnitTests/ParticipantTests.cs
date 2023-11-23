using DomeGym.Domain.UnitTests.TestUtils.Participants;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.TimeRanges;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class ParticipantTests
{
    [Fact]
    public void AddSessionToSchedule_WhenSessionOverlapsWithAnotherSession_ShouldFail()
    {
        // Given
        var participant = ParticipantFactory.CreateParticipant();

        var session1 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(1, 2),
            id: Guid.NewGuid());
    
        var session2 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(1, 2),
            id: Guid.NewGuid());

        // When
        var addSessionResult1 = participant.AddToSchedule(session1);
        var addSessionResult2 = participant.AddToSchedule(session2);
    
        // Then
        addSessionResult1.IsError.Should().BeFalse();
        addSessionResult2.IsError.Should().BeTrue();

    }
}