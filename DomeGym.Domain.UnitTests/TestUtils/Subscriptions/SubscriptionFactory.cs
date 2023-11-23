namespace DomeGym.Domain.UnitTests.TestUtils.Subscriptions;

using DomeGym.Domain.Subscriptions;
using TestConstants;

public static class SubscriptionFactory
{
    public static Subscription CreateSubscription() => new(subscriptionType: Constants.Subscriptions.DefaultSubscriptionType);
}