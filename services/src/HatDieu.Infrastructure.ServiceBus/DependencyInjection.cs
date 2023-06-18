using HatDieu.ApplicationCore.Configurations;
using HatDieu.ApplicationCore.Contracts;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace HatDieu.Infrastructure.ServiceBus;

public static class DependencyInfo
{
    public static IServiceCollection AddInfrastructureServiceBus(this IServiceCollection services,
        string? azureServiceBusConnection, ContractOptions contractOptions)
    {
        services.AddMassTransit(c =>
        {
            c.AddHealthChecks();
            c.AddServiceBusMessageScheduler();
            c.SetKebabCaseEndpointNameFormatter();

            c.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(azureServiceBusConnection);
                cfg.UseServiceBusMessageScheduler();

                var notification = contractOptions.Notification;
                cfg.Send<NotificationContract>(s =>
                {
                    s.UseSessionIdFormatter(c => c.Message.RequestId.ToString());
                    s.UsePartitionKeyFormatter(c => c.Message.Type);
                });
                cfg.Message<NotificationContract>(m => { m.SetEntityName(notification.TopicName); });
                cfg.Publish<NotificationContract>(x => { x.EnablePartitioning = true; });
                cfg.SubscriptionEndpoint<NotificationContract>(notification.SubscriptionName,
                    e => { });
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}

public class AppTopicNameFormatter<T> : IMessageEntityNameFormatter<T>
    where T : class
{
    public AppTopicNameFormatter(string topicName)
    {
        TopicName = topicName;
    }

    public string TopicName { get; }

    public string FormatEntityName()
    {
        // seriously, please don't do this, like, ever.
        return TopicName;
    }
}