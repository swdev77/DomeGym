using DomeGym.Domain.Common;
using DomeGym.Domain.Rooms;
using ErrorOr;

namespace DomeGym.Domain.Gyms;

public class Gym(Guid? id = null, int maxRooms = 1) : AggregateRoot(id ?? Guid.NewGuid())
{
    private readonly List<Guid> _roomIds = [];
    private readonly int _maxRooms = maxRooms;

    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Contains(room.Id))
        {
            return Error.Conflict(description: "Room already exists in gym");
        }

        if (_roomIds.Count >= _maxRooms)
        {
            return GymErrors.CannotHaveMoreRoomsThanSubscriptionAllows;
        }

        _roomIds.Add(room.Id);

        return Result.Success;
    }
}