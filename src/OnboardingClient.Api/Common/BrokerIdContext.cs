namespace OnboardingClient.Api.Common;

public sealed class BrokerService
{
    public string Name { get; init; } = "";
    public string Author { get; init; } = "";
    public string Desc { get; init; } = "";
}

public sealed class BrokerIdContext
{
    public string BrokerId { get; }
    public IReadOnlyList<BrokerService> Services { get; }

    public BrokerIdContext(string brokerId, IEnumerable<BrokerService> services)
    {
        BrokerId = brokerId;
        Services = services.ToList().AsReadOnly();
    }

    public bool HasService(string name) => Services.Any(s => s.Name == name);
}
