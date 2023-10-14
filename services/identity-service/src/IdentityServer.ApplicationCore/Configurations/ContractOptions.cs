namespace IdentityServer.ApplicationCore.Configurations;

public class ContractOptions
{
    public ContractDetailOptions Notification { get; set; }
}

public class ContractDetailOptions
{
    public string TopicName { get; set; } = string.Empty;
    public string SubscriptionName { get; set; } = string.Empty;
    public bool EnablePartitioning { get; set; }
}