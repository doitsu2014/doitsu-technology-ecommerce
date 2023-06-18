using Hangfire.Redis.StackExchange;

namespace HatDieu.Infrastructure.Options;

public class InfrastructureOptions
{
    public HangfireOptions Hangfire { get; set; }
    public RedisStorageOptions Redis { get; set; }
}