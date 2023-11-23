using ErrorOr;

namespace DomeGym.Domain;

public class Session(
    DateOnly date,
    TimeRange time,
    int maxParticipants,
    Guid trainerId,
    Guid? id = null)
{
    public Guid Id { get; } = id ?? Guid.NewGuid();
    public DateOnly Date { get; } = date;
    public TimeRange Time { get; } = time;
    private readonly Guid _trainerId = trainerId;
    private readonly List<Guid> _participantIds = [];
    private readonly int _maxParticipants = maxParticipants;


    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CanNotCancelReservationTooCloseToSession;
        }

        if (!_participantIds.Remove(participant.Id))
        {
            return Error.NotFound("Participant not found");
        }

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;

        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHours;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_participantIds.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        _participantIds.Add(participant.Id);

        return Result.Success;
    }
}