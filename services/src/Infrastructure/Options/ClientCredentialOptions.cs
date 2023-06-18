using Microsoft.Extensions.Configuration;

namespace HatDieu.Infrastructure.Options;

public class ClientCredentialOptions
{
    public const string Key = "ClientCredential";
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;

    public static ClientCredentialOptions Create(ConfigurationManager builderConfiguration)
    {
        var options = new ClientCredentialOptions();
        builderConfiguration.GetSection(Key).Bind(options);
        return options;
    }
}