using ErrorOr;

namespace DomeGym.Domain.Participants;

public static class ParticipantErrors
{
    public static readonly Error CannotHaveTwoOrMoreOverlappingSessions = Error.Conflict(
        code: "CannotHaveTwoOrMoreOverlappingSessions",
        description: "Cannot have two or more overlapping sessions");
}