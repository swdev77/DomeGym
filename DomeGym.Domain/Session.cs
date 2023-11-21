using ErrorOr;

namespace DomeGym.Domain;

public class Session(
    DateOnly date,
    TimeOnly startTime,
    TimeOnly endTime,
    int maxParticipants,
    Guid trainerId,
    Guid? id = null)
{
    private readonly Guid _id = id ?? Guid.NewGuid();
    private readonly Guid _trainerId = trainerId;
    private readonly List<Guid> _participantIds = [];
    private readonly DateOnly _date = date;
    private readonly TimeOnly _startTime = startTime;
    private readonly TimeOnly _endTime = endTime;
    private readonly int _maxParticipants = maxParticipants;

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if(IsTooCloseToSession(dateTimeProvider.UtcNow))
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

        return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
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