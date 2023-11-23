using DomeGym.Domain.Common;
using DomeGym.Domain.Common.Entities;
using DomeGym.Domain.Sessions;
using ErrorOr;

namespace DomeGym.Domain.Rooms;

public class Room(Guid id, int maxDailySessions, Schedule? schedule = null) : Entity(id)
{
    private readonly List<Guid> _sessionIds = [];
    private readonly int _maxDailySessions = maxDailySessions;
    private readonly Schedule _schedule = schedule ?? Schedule.Empty();

    public ErrorOr<Success> ScheduleSession(Session session)
    {
        if (_sessionIds.Contains(session.Id))
        {
            return Error.Conflict("This session is already exists");
        }

        if (_sessionIds.Count >= _maxDailySessions)
        {
            return RoomErrors.CannotHaveMoreSessionsThanSubscriptionAllows;
        }

        var result = _schedule.BookTimeSlot(session.Date, session.Time);

        if (result.IsError && result.FirstError.Type == ErrorType.Conflict)
        {
            return RoomErrors.CannotHaveTwoOrMoreOverlappingSessions;
        }

        _sessionIds.Add(session.Id);

        return Result.Success;
    }
}