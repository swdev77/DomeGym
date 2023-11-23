using ErrorOr;

namespace DomeGym.Domain.Rooms;

public static class RoomErrors
{
    public static readonly Error CannotHaveMoreSessionsThanSubscriptionAllows = Error.Validation(
            code: "CannotHaveMoreSessionsThanSubscriptionAllows ",
            description: "Cannot add more session then allowed");

    public static readonly Error CannotHaveTwoOrMoreOverlappingSessions = Error.Validation(
        code: "CannotHaveTwoOrMoreOverlappingSessions",
        description: "Can not have two or more overlapping sessions");
}