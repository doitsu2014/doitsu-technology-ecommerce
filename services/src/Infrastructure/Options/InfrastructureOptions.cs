using Hangfire.Redis.StackExchange;

namespace Infrastructure.Options;

public class InfrastructureOptions
{
    public HangfireOptions Hangfire { get; set; }
    public RedisStorageOptions Redis { get; set; }
}