using DomeGym.Domain.Common;

namespace DomeGym.Domain.Sessions;

public class Reservation(
    Guid participantId,
    Guid? id = null) : Entity(id ?? Guid.NewGuid())
{
    public Guid ParticipantId { get; } = participantId;
}