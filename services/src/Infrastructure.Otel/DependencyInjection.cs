using System.Text;
using MassTransit.Logging;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace HatDieu.Infrastructure.Otel;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureOtel(this IServiceCollection services,
        string? instanceName,
        Action<JaegerExporterOptions> configJaeger)
    {
        if (string.IsNullOrEmpty(instanceName))
        {
            throw new ArgumentException("Instance name is required", nameof(instanceName));
        }

        services.AddOpenTelemetry().WithTracing(b =>
        {
            b
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(instanceName))
                .AddSource(DiagnosticHeaders.DefaultListenerName) // MassTransit ActivitySource
                .AddAspNetCoreInstrumentation(options =>
                {
                    options.EnrichWithHttpRequest = (activity, httpRequest) =>
                    {
                        activity.SetTag("requestProtocol", httpRequest.Protocol);
                        activity.SetTag("requestHeaderAuthorization",
                            httpRequest.Headers.Authorization.ToString());
                        activity.SetTag("requestBodyLength", httpRequest.ContentLength.ToString());
                        activity.SetTag("requestBodyContentType", httpRequest.ContentType);
                    };

                    options.EnrichWithHttpResponse = (activity, httpResponse) =>
                    {
                        activity.SetTag("responseBodyLength", httpResponse.ContentLength.ToString());
                        activity.SetTag("responseBodyContentType", httpResponse.ContentType);
                    };

                    options.EnrichWithException = (activity, exception) =>
                    {
                        activity.SetTag("exception.message", exception.Message);
                        activity.SetTag("exception.stacktrace", exception.StackTrace);
                        activity.SetTag("exception.source", exception.Source);
                        activity.SetTag("exception.helplink", exception.HelpLink);
                        activity.SetTag("exception.exitingInnerException",
                            (exception.InnerException is not null).ToString());
                    };
                })
                .AddHttpClientInstrumentation(options =>
                {
                    options.EnrichWithHttpRequestMessage = (activity, request) =>
                    {
                        if (request.Content is null) return;

                        // Get raw string from request body with masking
                        var output = request.Content.ReadAsByteArrayAsync()
                            .GetAwaiter()
                            .GetResult()
                            .ToArray();
                        activity.SetTag("requestHeaderAuthorization",
                            request.Headers.Authorization?.ToString());
                        var body = Encoding.UTF8.GetString(output);
                        activity.SetTag("requestBody", body);
                        activity.SetTag("requestBody.length", body.Length.ToString());
                    };

                    options.EnrichWithHttpResponseMessage = (activity, response) =>
                    {
                        if (!response.IsSuccessStatusCode) return;

                        var output = response.Content.ReadAsByteArrayAsync()
                            .GetAwaiter()
                            .GetResult()
                            .ToArray();
                        var body = Encoding.UTF8.GetString(output);
                        activity.SetTag("responseBody", body);
                        activity.SetTag("responseBody.length", body.Length.ToString());
                    };

                    options.EnrichWithException = (activity, exception) =>
                    {
                        activity.SetTag("exception.message", exception.Message);
                        activity.SetTag("exception.stacktrace", exception.StackTrace);
                        activity.SetTag("exception.source", exception.Source);
                        activity.SetTag("exception.helplink", exception.HelpLink);
                        activity.SetTag("exception.exitingInnerException",
                            (exception.InnerException is not null).ToString());
                    };
                })
                .AddSqlClientInstrumentation(options =>
                {
                    options.SetDbStatementForText = true;
                    options.SetDbStatementForStoredProcedure = true;
                    options.RecordException = true;
                });

            b.AddJaegerExporter(configJaeger.Invoke);
#if DEBUG
            // b.AddConsoleExporter();
#endif
        });

        return services;
    }
}