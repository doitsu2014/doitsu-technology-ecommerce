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
    .AddGlobalFeatures(
        "OrchardCore.Apis.GraphQL",
        "OrchardCore.Commerce.ContentFields",
        "OrchardCore.Commerce",
        "OrchardCore.Commerce.CurrencySettingsSelector",
        "OrchardCore.Commerce.Tax.CustomTaxRates",
        "OrchardCore.Commerce.Inventory",
        "OrchardCore.Commerce.Promotion",
        "OrchardCore.Commerce.SessionCartStorage",
        "OrchardCore.Commerce.Tax",
        "OrchardCore.Feeds",
        "OrchardCore.Flows",
        "OrchardCore.Forms",
        "OrchardCore.Layers",
        "OrchardCore.Shortcodes.Templates",
        "OrchardCore.Widgets",
        "OrchardCore.Contents.Deployment.AddToDeploymentPlan",
        "OrchardCore.AdminDashboard",
        "OrchardCore.AdminMenu",
        "OrchardCore.Alias",
        "OrchardCore.ArchiveLater",
        "OrchardCore.ContentFields",
        "OrchardCore.ContentFields.Indexing.SQL",
        "OrchardCore.ContentFields.Indexing.SQL.UserPicker",
        "OrchardCore.ContentPreview",
        "OrchardCore.ContentTypes",
        "OrchardCore.Contents",
        "OrchardCore.Contents.Deployment.ExportContentToDeploymentTarget",
        "OrchardCore.Contents.FileContentDefinition",
        "OrchardCore.Html",
        "OrchardCore.Liquid",
        "OrchardCore.Lists",
        "OrchardCore.Markdown",
        "OrchardCore.Media",
        "OrchardCore.Media.Cache",
        "OrchardCore.Media.Slugify",
        "OrchardCore.PublishLater",
        "OrchardCore.Queries",
        "OrchardCore.Seo",
        "OrchardCore.Sitemaps",
        "OrchardCore.Sitemaps.Cleanup",
        "OrchardCore.Sitemaps.RazorPages",
        "OrchardCore.Spatial",
        "OrchardCore.Queries.Sql",
        "OrchardCore.Taxonomies",
        "OrchardCore.Taxonomies.ContentsAdminList",
        "OrchardCore.Title",
        "OrchardCore.Contents.Deployment.Download",
        "OrchardCore.Tenants.Distributed",
        "OrchardCore.Redis",
        "OrchardCore.Redis.Bus",
        "OrchardCore.Redis.Cache",
        "OrchardCore.Redis.DataProtection",
        "OrchardCore.Redis.Lock",
        "OrchardCore.AutoSetup")
    .AddDatabaseShellsConfiguration()

    // Orchard Specific Pipeline
    .ConfigureServices(services => { })
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