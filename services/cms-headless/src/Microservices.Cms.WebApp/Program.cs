using OrchardCore.FileStorage;
using OrchardCore.Logging;
using OrchardCore.Media;
using OrchardCore.Media.Core;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, configBuilder) =>
{
    configBuilder.ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext();
});

builder.Services
    .AddOrchardCms()
    .AddDatabaseShellsConfiguration()
    // Orchard Specific Pipeline
    .ConfigureServices(services =>
    {
    })
    // .Configure((app, routes, services) => { });
    ;
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseOrchardCore(c => c.UseSerilogTenantNameLogging());

app.Run();