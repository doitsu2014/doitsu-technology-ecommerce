using System.Reflection;
using Hangfire;
using Hangfire.JobsLogger;
using Hangfire.Redis.StackExchange;
using HatDieu.Infrastructure.Jobs;
using HatDieu.Infrastructure.Options;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.System.Text.Json;
using static HatDieu.Infrastructure.Constants;

namespace HatDieu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        Func<string> getInstanceName,
        Func<string> getConnectionString,
        Action<InfrastructureOptions> mapInfrastructureOptions = null,
        Action<HangfireOptions> mapHangfireOptions = null,
        Action<RedisConfiguration> mapRedisOptions = null,
        Action<BackgroundJobOptions> mapBackgroundJobOptions = null
    )
    {
        var instanceName = getInstanceName();

        var infrastructureOptions = new InfrastructureOptions();
        mapInfrastructureOptions?.Invoke(infrastructureOptions);

        var redisStorageOptions = new RedisConfiguration();
        mapRedisOptions?.Invoke(redisStorageOptions);

        services.Configure(mapBackgroundJobOptions);

        services.AddCustomStackExchangeRedisExtensions<SystemTextJsonSerializer>((sp) =>
        {
            return new[]
            {
                redisStorageOptions
            };
        });

        services.AddDistributedMemoryCache();

        var hangfireOptions = new HangfireOptions();
        mapHangfireOptions?.Invoke(hangfireOptions);

        if (hangfireOptions.Enabled)
        {
            // Configure that one into hangfire options
            hangfireOptions.ConfigureRedisConfiguration(redisStorageOptions);

            services.AddHangfire((sp, conf) =>
            {
                conf.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseRedisStorage(ConnectionMultiplexer.Connect(redisStorageOptions.ConfigurationOptions.ToString()),
                        hangfireOptions.RedisStorageOptions)
                    .WithJobExpirationTimeout(TimeSpan.FromDays(7))
                    .UseJobsLogger();
            });

            services.AddHangfireServer(options =>
            {
                options.ServerName = instanceName;
                options.WorkerCount = hangfireOptions.WorkerCount;
            });
        }

        services.AddDataAccessService();
        services.AddDatabase(getConnectionString() ?? string.Empty);

        services.AddScoped<SyncAllEntitiesDailyJob>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("ApplicationDbContext connection string is null or empty",
                nameof(connectionString));
        }

        var appMigrationAssembly = typeof(ApplicationDbContext)
            .GetTypeInfo()
            .Assembly
            .GetName().Name;

        var binding = new Action<DbContextOptionsBuilder>(b =>
        {
            b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(appMigrationAssembly));
        });

        services.AddDbContext<ApplicationDbContext>(binding);
        return services;
    }

    public static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddCustomStackExchangeRedisExtensions<T>(
        this IServiceCollection services,
        Func<IServiceProvider, IEnumerable<RedisConfiguration>> redisConfigurationFactory)
        where T : class, ISerializer
    {
        services.AddSingleton<IRedisClientFactory, RedisClientFactory>();
        services.AddSingleton<ISerializer, T>();

        services.AddSingleton(provider => provider
            .GetRequiredService<IRedisClientFactory>()
            .GetDefaultRedisClient());

        services.AddSingleton(provider => provider
            .GetRequiredService<IRedisClientFactory>()
            .GetDefaultRedisClient()
            .GetDefaultDatabase());

        services.AddSingleton(redisConfigurationFactory);

        return services;
    }

    public static IServiceCollection AddInfrastructureSecurity(this IServiceCollection services,
        Action<SecurityOptions> mapSecurityOptions,
        Action<ClientCredentialOptions> mapClientCredentialOptions)
    {
        var securityOptions = new SecurityOptions();
        mapSecurityOptions.Invoke(securityOptions);

        var clientCredentialOptions = new ClientCredentialOptions();
        mapClientCredentialOptions.Invoke(clientCredentialOptions);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = securityOptions.Authority;
                options.Audience = securityOptions.ApiName;
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                options.RequireHttpsMetadata = false;
                options.MapInboundClaims = false;
            });

        services.AddAuthorization(options =>
        {
            AuthorizationPolicyBuilder GetDefaultBuilder() => new(JwtBearerDefaults.AuthenticationScheme);

            options.AddPolicy(Policy.Admin, GetDefaultBuilder()
                .RequireClaim(JwtClaimTypes.Scope, Scope.Admin)
                .Build());

            options.AddPolicy(Policy.Writer, GetDefaultBuilder()
                .RequireClaim(JwtClaimTypes.Scope, Scope.Admin, Scope.Write)
                .Build());

            options.AddPolicy(Policy.Reader, GetDefaultBuilder()
                .RequireClaim(JwtClaimTypes.Scope, Scope.Admin, Scope.Write, Scope.Read)
                .Build());
        });


        services.AddClientCredentialsTokenManagement(options => { })
            .AddClient(TokenManagement.DataCrawlerPayrixWithAllScopes,
                client =>
                {
                    client.TokenEndpoint = $"{securityOptions.Authority}/connect/token";
                    client.ClientId = clientCredentialOptions.ClientId;
                    client.ClientSecret = clientCredentialOptions.ClientSecret;
                    client.ClientCredentialStyle = ClientCredentialStyle.PostBody;
                });

        return services;
    }
}