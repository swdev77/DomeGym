using Throw;

namespace DomeGym.Domain;

public record TimeRange()
{
    public TimeOnly Start { get; }
    public TimeOnly End { get; }
    public TimeRange(TimeOnly start, TimeOnly end) : this()
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
}