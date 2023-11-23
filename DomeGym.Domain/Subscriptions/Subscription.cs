using DomeGym.Domain.Common;
using DomeGym.Domain.Gyms;
using ErrorOr;

namespace DomeGym.Domain.Subscriptions;

public class Subscription(SubscriptionType subscriptionType, Guid? id = null)
    : AggregateRoot(id ?? Guid.NewGuid())
{
    private readonly List<Guid> gymIds = [];

    private readonly SubscriptionType _subscriptionType = subscriptionType;

    public ErrorOr<Success> AddGym(Gym gym)
    {
        if (gymIds.Contains(gym.Id))
        {
            return Error.Conflict("Gym already exists in subscription");
        }

        if (gymIds.Count >= GetMaxGyms())
        {
            return SubscriptionErrors.CannotHaveMoreGymsThanSubscriptionAllows;
        }

        gymIds.Add(gym.Id);

        return Result.Success;
    }

    public int GetMaxGyms()
    {
        return _subscriptionType switch
        {
            SubscriptionType.Free => 1,
            SubscriptionType.Starter => 1,
            SubscriptionType.Pro => 3,
            _ => throw new InvalidOperationException(nameof(_subscriptionType))
        };
    }
}
