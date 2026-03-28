using Application.Abstractions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Logging;

public static class InfrastructureLoggingRegistration
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<ILogger, Logger>();

        return services;
    }
}
