using ApplicationCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace Api;

public static class HostingExtensions
{
    public static void AddSwagger(this IServiceCollection services, string authority)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.UseInlineDefinitionsForEnums();
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Microservices Data Crawler Payrix",
                Version = "v1",
                Description = "Microservices Data Crawler Payrix API",
            });
            opt.AddSecurityDefinition("oauth", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Name = HeaderNames.Authorization,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    ClientCredentials = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri($"{authority}/connect/token"),
                        RefreshUrl = new Uri($"{authority}/connect/token"),
                        AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
                        Scopes = new Dictionary<string, string>
                        {
                            {
                                PolicyConstants.ApiResourceScopeAdmin,
                                PolicyConstants.ApiResourceScopeAdmin
                            }
                        }
                    }
                }
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                            {Type = ReferenceType.SecurityScheme, Id = "oauth"},
                    },
                    new List<string>()
                }
            });
        });
    }
}