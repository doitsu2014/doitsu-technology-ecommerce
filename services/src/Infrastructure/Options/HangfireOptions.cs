using Hangfire.Redis.StackExchange;
using StackExchange.Redis.Extensions.Core.Configuration;

namespace HatDieu.Infrastructure.Options;

public class HangfireOptions
{
    public bool                Enabled             { get; set; }
    public int                 WorkerCount         { get; set; }
    public RedisStorageOptions RedisStorageOptions { get; set; }

    public void ConfigureRedisConfiguration(RedisConfiguration redisConfiguration)
    {
        this.RedisStorageOptions.Prefix = $"{redisConfiguration.KeyPrefix}hangfire:";
    }
}