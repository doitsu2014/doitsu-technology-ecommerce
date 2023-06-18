using Microsoft.Extensions.Configuration;

namespace HatDieu.Infrastructure.PayrixGateway.Options;

public class PayrixGatewayOptions
{
    public const string Key = "PayrixGateway";

    public string Url { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;

    public static PayrixGatewayOptions Create(ConfigurationManager builderConfiguration)
    {
        var options = new PayrixGatewayOptions();
        builderConfiguration.GetSection(Key).Bind(options);
        return options;
    }
}