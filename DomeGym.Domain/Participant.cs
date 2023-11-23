using DomeGym.Domain.Common;
using ErrorOr;

namespace DomeGym.Domain;

public class Participant(
    Guid userId,
    Guid? id = null) : Entity(id ?? Guid.NewGuid())
{
    private readonly Guid _userId = userId;
    private readonly List<Guid> _sessionIds = [];
    private readonly Schedule _schedule = Schedule.Empty();

    public ErrorOr<Success> AddToSchedule(Session session)
    {
        if (_sessionIds.Contains(session.Id))
        {
            return SessionErrors.SessionAlreadyExists;
        }

        ErrorOr<Success> bookTimeSlotResult = _schedule.BookTimeSlot(session.Date, session.Time);

        if(bookTimeSlotResult.IsError)
        {
            return bookTimeSlotResult.FirstError.Type == ErrorType.Conflict
                ? ParticipantErrors.CannotHaveTwoOrMoreOverlappingSessions
                : bookTimeSlotResult.Errors;
        }

        _sessionIds.Add(session.Id);
        
        return Result.Success;
    }
}
