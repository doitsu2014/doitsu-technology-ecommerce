using System.Reflection;
using HatDieu.ApplicationCore.Interfaces.DataAccessServices;
using HatDieu.Infrastructure.Options;
using HatDieu.Infrastructure.PayrixGateway.DataAccessServices;
using HatDieu.Infrastructure.PayrixGateway.Options;
using Microsoft.Extensions.DependencyInjection;

namespace HatDieu.Infrastructure.PayrixGateway;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructurePayrixGateway(this IServiceCollection services,
        Action<SecurityOptions> mapSecurityOptions,
        Action<PayrixGatewayOptions> mapPayrixGatewayOptions)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);

        var securityOptions = new SecurityOptions();
        mapSecurityOptions.Invoke(securityOptions);

        var payrixGatewayOptions = new PayrixGatewayOptions();
        mapPayrixGatewayOptions.Invoke(payrixGatewayOptions);

        services.AddHttpClient<IPayrixGatewayDas, PayrixGatewayDas>(options =>
            {
                options.BaseAddress = new Uri(payrixGatewayOptions.Url);
            })
            .AddClientCredentialsTokenHandler(Constants.TokenManagement.DataCrawlerPayrixWithAllScopes);
        return services;
    }
}