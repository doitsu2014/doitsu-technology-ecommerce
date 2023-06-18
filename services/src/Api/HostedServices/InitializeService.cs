using Hangfire;
using HatDieu.ApplicationCore;
using HatDieu.Infrastructure;
using HatDieu.Infrastructure.Jobs;
using HatDieu.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HatDieu.Api.HostedServices;

public class InitializeService : IHostedService
{
    private readonly ILogger<InitializeService> _logger;
    private readonly IRecurringJobManagerV2 _recurringJobManagerV2;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly BackgroundJobOptions _backgroundJobOptions;

    public InitializeService(ILogger<InitializeService> logger,
        IRecurringJobManagerV2 recurringJobManagerV2,
        IOptions<BackgroundJobOptions> backgroundJobOptions,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _recurringJobManagerV2 = recurringJobManagerV2;
        _serviceScopeFactory = serviceScopeFactory;
        _backgroundJobOptions = backgroundJobOptions.Value;
    }

    public async Task StartAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Start running Initialize Service");

        _logger.LogInformation("1. Migrate Database");
        using var scope = _serviceScopeFactory.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await applicationDbContext.Database.MigrateAsync(ct);

        _logger.LogInformation("2. Add or update recurring jobs");
        _logger.LogInformation("2.1. Sync All Entities Daily");
        RecurringJob.AddOrUpdate<SyncAllEntitiesDailyJob>(nameof(SyncAllEntitiesDailyJob),
            (job) => job.ExecuteAsync(ct),
            _backgroundJobOptions.SyncAllEntitiesDaily.Cron,
            new RecurringJobOptions()
            {
                TimeZone = _backgroundJobOptions.SyncAllEntitiesDaily.TimeZone.ToTimeZoneInfo()
            });
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}