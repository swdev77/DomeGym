using System.Net.NetworkInformation;

namespace DomeGym.Domain.UnitTests.TestUtils.Subscriptions;

using TestConstants;

public static class SubscriptionFactory
{
    public static Subscription CreateSubscription() => new(subscriptionType: Constants.Subscriptions.DefaultSubscriptionType);
}