using System.Text.Json;
using Api;
using Api.Filters;
using Api.HostedServices;
using ApplicationCore;
using ApplicationCore.Configurations;
using Hangfire;
using Infrastructure;
using Infrastructure.Otel;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.jobs.json", optional: true, reloadOnChange: false);
builder.Configuration.AddJsonFile("secrets/appsettings.secrets.json", optional: true, reloadOnChange: false);

builder.Host
    .UseSerilog((ctx, lc) => { lc.ReadFrom.Configuration(ctx.Configuration); });

builder.Services.AddControllers(options => { options.Filters.Add<ApiExceptionFilterAttribute>(); })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.MaxDepth = 10;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

var contractConfigurations = new ContractOptions();
builder.Configuration.GetSection("Contract").Bind(contractConfigurations);

builder.Services.AddHealthChecks();

var instanceName = builder.Configuration.GetValue<string>("InstanceName");
builder.Services.AddApplicationCore()
    .AddInfrastructure(
        () => instanceName,
        () => builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)),
        options => { },
        options => { builder.Configuration.GetSection("Hangfire").Bind(options); },
        options => { builder.Configuration.GetSection("Redis").Bind(options); },
        options => { builder.Configuration.GetSection("BackgroundJob").Bind(options); })
    .AddInfrastructureSecurity(
        securityOptions => { builder.Configuration.GetSection("Security").Bind(securityOptions); },
        clientCredentialOptions =>
        {
            builder.Configuration.GetSection("ClientCredential").Bind(clientCredentialOptions);
        })
    .AddInfrastructureOtel(instanceName, jaegerOptions =>
    {
        var jaegerSection = builder.Configuration.GetSection("Jaeger");
        jaegerOptions.AgentHost = jaegerSection.GetValue<string>("AgentHost");
        jaegerOptions.AgentPort = jaegerSection.GetValue<int>("AgentPort");
    });

// Add Swagger and Security on Swagger
var authority = builder.Configuration.GetValue<string>("Security:Authority");
builder.Services.AddSwagger(authority!);

builder.Services.AddHostedService<InitializeService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(_ => { });
    app.UseSwaggerUI(options =>
    {
        options.OAuthAppName("Swagger Client");
        options.OAuthClientId("");
        options.OAuthClientSecret("");
        options.OAuthScopes(PolicyConstants.ApiResourceScopeAdmin); // select Admin Scope by default
    });
}

if (app.Configuration.GetSection("Hangfire").GetValue<bool>("Enabled"))
{
    app.UseHangfireDashboard("/hangfire", new DashboardOptions()
    {
        Authorization = new[]
        {
            new HangfireAuthorizationFilter(PolicyConstants.PolicyAdmin)
        }
    });
}

app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => "Microservices Data Crawler Payrix API is running on");
app.MapHealthChecks("/healthz", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = AppExtensions.WriteResponse
});
app.UseEndpoints(e => { e.MapControllers(); });
app.Run();