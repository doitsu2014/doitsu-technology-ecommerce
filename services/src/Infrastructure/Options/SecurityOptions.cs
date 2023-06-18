using Microsoft.Extensions.Configuration;

namespace Infrastructure.Options;

public class SecurityOptions
{
    public const string Key = "Security";
    public string Authority { get; set; } = string.Empty;
    public string ApiName { get; set; } = "microservices.data-crawler.payrix";

    public static SecurityOptions Create(ConfigurationManager builderConfiguration)
    {
        var options = new SecurityOptions();
        builderConfiguration.GetSection(Key).Bind(options);
        return options;
    }
}