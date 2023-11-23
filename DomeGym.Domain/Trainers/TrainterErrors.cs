using ErrorOr;

namespace DomeGym.Domain.Trainers;

public static class TrainerErrors
{
    public readonly static Error CannotHaveTwoOrMoreOverlappingSessions = Error.Conflict(
        code: "CannotHaveTwoOrMoreOverlappingSessions",
        description: "Can not have two or more overlapping sessions"
    );
}