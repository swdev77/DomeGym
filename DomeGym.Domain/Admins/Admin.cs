using DomeGym.Domain.Common;

namespace DomeGym.Domain.Admins;

public class Admin(Guid? Id = null) : AggregateRoot(Id ?? Guid.NewGuid())
{
    private readonly Guid _userId;
    private readonly Guid _subscriptionId;
}
