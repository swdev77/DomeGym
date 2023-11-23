namespace DomeGym.Domain.UnitTests.TestUtils.Sessions;

using DomeGym.Domain.Sessions;
using TestConstants;
public static class SessionFactory 
{
    public static Session CreateSession(
        DateOnly? date = null,
        TimeRange? time = null, 
        int maxParticipants = Constants.Session.MaxParticipants,
        Guid? id = null)
    {
        return new Session(
            date: date ?? Constants.Session.Date,
            time: time ?? Constants.Session.TimeRange,
            maxParticipants: maxParticipants,
            trainerId: Constants.Trainer.Id,
            id: id ?? Constants.Session.Id);
    }
}