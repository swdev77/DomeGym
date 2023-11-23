using System.Data.Common;
using DomeGym.Domain.UnitTests.TestUtils.Gym;
using DomeGym.Domain.UnitTests.TestUtils.Subscriptions;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class SubscriptionTests 
{
    [Fact]
    public void AddGym_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        var subscription = SubscriptionFactory.CreateSubscription();

        var gyms = Enumerable.Range(0, subscription.GetMaxGyms()+1)
            .Select(_ => GymFactory.CreateGym(id: Guid.NewGuid()))
            .ToList();

        var addGymResults = gyms.ConvertAll(subscription.AddGym);

        var allButLastAddGymResults = addGymResults.Take(..^1);
        allButLastAddGymResults.Should().AllSatisfy(result => result.IsError.Should().BeFalse());

        var lastAddGymResult = addGymResults.Last();
        lastAddGymResult.IsError.Should().BeTrue();
        lastAddGymResult.FirstError.Should().Be(SubscriptionErrors.CannotHaveMoreGymsThanSubscriptionAllows);
    }
}