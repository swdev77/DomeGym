using DomeGym.Domain.Common;

namespace DomeGym.Domain.Admins;

public class Admin(Guid userId, Guid subscriptionId, Guid? Id = null) : AggregateRoot(Id ?? Guid.NewGuid())
{
    private readonly Guid _userId = userId;
    private readonly Guid _subscriptionId = subscriptionId;
}
