using ErrorOr;

namespace DomeGym.Domain;

public static class SessionErrors 
{
    public readonly static Error CannotHaveMoreReservationsThanParticipants = Error.Validation(
        code: "CannotHaveMoreReservationsThanParticipants",
        description: "Cannot have more reservations than participants"
    );

    public readonly static Error CanNotCancelReservationTooCloseToSession = Error.Validation(
        code: "CanNotCancelReservationTooCloseToSession",
        description: "Can not cancel reservation too close to session" 
    );

    public readonly static Error SessionAlreadyExists = Error.Conflict(
        code: "SessionAlreadyExists",
        description: "Session already exists"
    );
}