namespace DomeGym.Domain.UnitTests.TestUtils.Sessions;

using TestConstants;
public static class SessionFactory 
{
    public static Session CreateSession(
        DateOnly? date = null,
        TimeOnly? startTime = null,
        TimeOnly? endTime = null,
        int? maxParticipants = null,
        Guid? id = null)
    {
        return new Session(
            date: date ?? Constants.Session.Date,
            startTime: startTime ?? Constants.Session.StartTime,
            endTime: endTime ?? Constants.Session.EndTime,
            maxParticipants: maxParticipants ?? Constants.Session.MaxParticipants,
            trainerId: Constants.Trainer.Id,
            id: id ?? Constants.Session.Id);
    }
}