using DomeGym.Domain.UnitTests.TestUtils.Gym;
using DomeGym.Domain.UnitTests.TestUtils.Rooms;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests.Gyms;

using DomeGym.Domain.Gyms;

public class GymTests
{
    [Fact]
    public void AddRoom_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        var gym = GymFactory.CreateGym(maxRooms: 1);
        var room1 = RoomFactory.CreateRoom(id: Guid.NewGuid());
        var room2 = RoomFactory.CreateRoom(id: Guid.NewGuid());

        var addRoom1Result = gym.AddRoom(room1);
        var addRoom2Result = gym.AddRoom(room2);

        addRoom1Result.IsError.Should().BeFalse();

        addRoom2Result.IsError.Should().BeTrue();
        addRoom2Result.FirstError.Should().Be(GymErrors.CannotHaveMoreRoomsThanSubscriptionAllows);
    }
}