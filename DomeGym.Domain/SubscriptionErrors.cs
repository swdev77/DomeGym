using ErrorOr;

namespace DomeGym.Domain;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanSubscriptionAllows = 
        Error.Validation(
            code: "CannotHaveMoreGymsThanSubscriptionAllows", 
            description: "Can not have more gyms than subscription allows");
}