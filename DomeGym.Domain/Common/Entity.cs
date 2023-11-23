namespace DomeGym.Domain.Common;

public abstract class Entity(Guid id)
{
    public Guid Id { get; } = id;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Entity other) return false;

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}