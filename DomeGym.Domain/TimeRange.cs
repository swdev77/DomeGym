using DomeGym.Domain.Common;
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