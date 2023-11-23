using ErrorOr;

namespace DomeGym.Domain.Subscriptions;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanSubscriptionAllows =
        Error.Validation(
            code: "CannotHaveMoreGymsThanSubscriptionAllows",
            description: "Can not have more gyms than subscription allows");
}