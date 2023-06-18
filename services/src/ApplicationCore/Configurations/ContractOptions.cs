namespace HatDieu.ApplicationCore.Configurations;

public class ContractOptions
{
    public ContractDetailOptions? Notification { get; set; }
}

public class ContractDetailOptions
{
    public string? TopicName          { get; set; }
    public string? SubscriptionName   { get; set; }
    public bool?   EnablePartitioning { get; set; }
}