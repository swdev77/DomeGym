using DomeGym.Domain.Rooms;

namespace DomeGym.Domain.UnitTests.TestUtils.Rooms;

public class RoomFactory
{
    public static Room CreateRoom(int maxDailySessions = 10, Guid? id = null)
    {
        return new Room(id: id ?? Guid.NewGuid(), maxDailySessions: maxDailySessions);
    }
}