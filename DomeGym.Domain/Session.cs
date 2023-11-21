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

    public void CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if(IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            throw new Exception("Can not cancel reservation too close to session");
        }

        if (!_participantIds.Remove(participant.Id))
        {
            throw new Exception("Reservation not found");
        }
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;

        return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
    }

    public void ReserveSpot(Participant participant)
    {
        if (_participantIds.Count >= _maxParticipants)
            throw new Exception("Cannot have more reservation than max allowed.");

        _participantIds.Add(participant.Id);
    }
}