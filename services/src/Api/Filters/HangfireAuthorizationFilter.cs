using Hangfire.Dashboard;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Api.Filters;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly string _policyName;

    public HangfireAuthorizationFilter(string policyName)
    {
        _policyName = policyName;
    }

    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        var authenticationResult = httpContext
            .AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme)
            .GetAwaiter()
            .GetResult();
        var authService = httpContext.RequestServices.GetRequiredService<IAuthorizationService>();
        var logger = httpContext.RequestServices.GetRequiredService<ILogger<HangfireAuthorizationFilter>>();

        var authorizedResult = authService.AuthorizeAsync(authenticationResult.Principal!, _policyName)
            .GetAwaiter()
            .GetResult();

        if (authorizedResult.Succeeded) return true;

        var listOfReasons = authorizedResult.Failure?
            .FailureReasons
            .Select(reason =>
                $"{nameof(reason.Handler)} detected unauthorized-request with message: {reason.Message}.")
            .ToList();
        var reason = listOfReasons != null && listOfReasons.Any()
            ? listOfReasons.Aggregate((a, b) => $"{a}\n{b}")
            : string.Empty;
        if (!string.IsNullOrEmpty(reason))
        {
            logger.LogWarning(reason);
        }

        return false;
    }
}