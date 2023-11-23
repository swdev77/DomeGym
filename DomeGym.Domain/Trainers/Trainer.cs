using DomeGym.Domain.Common;
using DomeGym.Domain.Common.Entities;
using DomeGym.Domain.Sessions;
using ErrorOr;

namespace DomeGym.Domain.Trainers;

public class Trainer(Schedule? schedule = null, Guid? id = null) : AggregateRoot(id ?? Guid.NewGuid())
{
    private readonly Guid _id = id ?? Guid.NewGuid();
    private readonly List<Guid> _sessionIds = [];
    private readonly Schedule _schedule = schedule ?? Schedule.Empty();

    public ErrorOr<Success> AddSessionToSchedule(Session session)
    {
        if (_sessionIds.Contains(session.Id))
            return SessionErrors.SessionAlreadyExists;

        var bookTimeSlotResult = _schedule.BookTimeSlot(session.Date, session.Time);

        if (bookTimeSlotResult.IsError && bookTimeSlotResult.FirstError.Type == ErrorType.Conflict)
            return TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions;

        _sessionIds.Add(session.Id);
        return Result.Success;
    }
}