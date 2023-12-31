using ErrorOr;

namespace DomeGym.Domain.Common.Entities;

public class Schedule(Guid? id = null) : Entity(id ?? Guid.NewGuid())
{
    private readonly Dictionary<DateOnly, List<TimeRange>> _calendar = [];

    public static Schedule Empty() => new();

    public ErrorOr<Success> BookTimeSlot(DateOnly date, TimeRange time)
    {
        if (!_calendar.TryGetValue(date, out var times))
        {
            _calendar[date] = [time];
            return Result.Success;
        }

        if (times.Any(t => t.OverlapsWith(time)))
        {
            return Error.Conflict("Time slot is already booked");
        }

        return Result.Success;
    }
}
