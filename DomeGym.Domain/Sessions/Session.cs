using DomeGym.Domain.Common;
using DomeGym.Domain.Common.Interfaces;
using DomeGym.Domain.Participants;
using ErrorOr;

namespace DomeGym.Domain.Sessions;

public class Session(
    DateOnly date,
    TimeRange time,
    int maxParticipants,
    Guid trainerId,
    Guid? id = null) : AggregateRoot(id ?? Guid.NewGuid())
{
    public DateOnly Date { get; } = date;
    public TimeRange Time { get; } = time;
    private readonly Guid _trainerId = trainerId;
    private readonly List<Reservation> _reservations = [];
    private readonly int _maxParticipants = maxParticipants;


    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CanNotCancelReservationTooCloseToSession;
        }

        var reservation = _reservations.Find(r => r.ParticipantId == participant.Id);
        if (reservation is null)
        {
            return Error.NotFound("Participant not found");
        }

        _reservations.Remove(reservation);

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;

        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHours;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_reservations.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        if (_reservations.Any(r => r.ParticipantId == participant.Id))
        {
            return Error.Conflict("Participant already has a reservation");
        }

        _reservations.Add(new(participant.Id));

        return Result.Success;
    }
}