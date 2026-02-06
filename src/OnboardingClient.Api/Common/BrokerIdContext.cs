public sealed class BrokerIdContext
{
    public string BrokerId { get; }
    public HashSet<string> Services { get; }

    public BrokerIdContext(string brokerId, IEnumerable<string> services)
    {
        BrokerId = brokerId;
        Services = services.ToHashSet();
    }
}
