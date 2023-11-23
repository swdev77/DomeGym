using ErrorOr;

namespace DomeGym.Domain.Gyms;

public static class GymErrors
{
    public static readonly Error CannotHaveMoreRoomsThanSubscriptionAllows = Error.Validation(
        code: "CannotHaveMoreRoomsThanSubscriptionAllows",
        description: "Can not have more rooms than subscription allows"
    );
}