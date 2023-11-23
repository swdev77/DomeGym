using System.Security.Principal;

namespace DomeGym.Domain.Subscriptions;

public abstract record SubscriptionType
{
    private SubscriptionType() { }
    public record Free(string Name = nameof(Free), int Id = 0) : SubscriptionType();
    public record Starter(string Name = nameof(Starter), int Id = 1) : SubscriptionType();
    public record Pro(string Name = nameof(Pro), int Id = 2) : SubscriptionType();
}