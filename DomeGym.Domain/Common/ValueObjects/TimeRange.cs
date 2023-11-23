using DomeGym.Domain.Common;
using ErrorOr;
using Throw;

namespace DomeGym.Domain;

public class TimeRange : ValueObject
{
    public TimeOnly Start { get; }
    public TimeOnly End { get; }
    public TimeRange(TimeOnly start, TimeOnly end) 
    {
        Start = start.Throw().IfGreaterThanOrEqualTo(end);
        End = end;
    }

    public static ErrorOr<TimeRange> FromDateTimes(DateTime start, DateTime end)
    {
        if (start.Date != end.Date) return Error.Validation(description: "Start and end must be on the same date");
        
        if (start >= end) return Error.Validation(description: "Start must be before end");

        return new TimeRange(TimeOnly.FromDateTime(start), TimeOnly.FromDateTime(end));
    }

    public bool OverlapsWith(TimeRange other)
    {
       if (Start >= other.End) return false;
       if (other.Start >= End) return false;

       return true;
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}