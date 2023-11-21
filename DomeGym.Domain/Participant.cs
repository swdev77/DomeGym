namespace DomeGym.Domain;

public class Participant(
    Guid userId,
    Guid? id = null)
{
    public Guid Id { get; } = id ?? Guid.NewGuid();
    private readonly Guid _userId = userId;
    private readonly List<Guid> _sessionIds = [];
}