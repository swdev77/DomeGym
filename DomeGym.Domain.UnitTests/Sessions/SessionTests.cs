using DomeGym.Domain.Sessions;
using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Participants;
using DomeGym.Domain.UnitTests.TestUtils.Services;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests.Sessions;

public class SessionTests
{
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
    {
        // Arrange 
        var session = SessionFactory.CreateSession(maxParticipants: 1);
        var participant1 = ParticipantFactory.CreateParticipant(
            id: Guid.NewGuid(),
            userId: Constants.User.Id);
        var participant2 = ParticipantFactory.CreateParticipant(
            id: Guid.NewGuid(),
            userId: Constants.User.Id);

        // Act
        var reservationParticipant1Result = session.ReserveSpot(participant1);
        var reservationParticipant2Result = session.ReserveSpot(participant2);

        // Assert
        reservationParticipant1Result.IsError.Should().BeFalse();
        reservationParticipant2Result.FirstError.Should().Be(SessionErrors.CannotHaveMoreReservationsThanParticipants);
    }

    [Fact]
    public void CancelReservation_WhenCancellationIsTooCloseToSession_ShouldFailCancellation()
    {
        // Arrange
        var session = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: Constants.Session.TimeRange);

        var participant = ParticipantFactory.CreateParticipant();

        var cancellationDateTime = Constants.Session.Date.ToDateTime(TimeOnly.MinValue);

        // Act
        var reserveSpotResult = session.ReserveSpot(participant);
        var cancelReservationResult = session.CancelReservation(
            participant,
            new TestDateTimeProvider(fixedDateTime: cancellationDateTime));

        // Assert
        reserveSpotResult.IsError.Should().BeFalse();

        cancelReservationResult.IsError.Should().BeTrue();
        cancelReservationResult.FirstError.Should().Be(SessionErrors.CanNotCancelReservationTooCloseToSession);
    }
}