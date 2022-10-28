using Fathy.Common.Startup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Fathy.Common.Email;

public static class DependencyInjection
{
    public static void AddEmailService(this IServiceCollection services, OpenApiInfo openApiInfo)
    {
        services.AddStartupServices(openApiInfo);
        services.AddSingleton<IEmailRepository, EmailRepository>();
    }
}