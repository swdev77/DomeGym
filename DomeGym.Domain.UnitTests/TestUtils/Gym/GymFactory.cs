namespace DomeGym.Domain.UnitTests.TestUtils.Gym;

using DomeGym.Domain;

public class GymFactory
{
    public static Gym CreateGym(int maxRooms = 1, Guid? id = null)
    {
        return new Gym(maxRooms: maxRooms);
    }
}