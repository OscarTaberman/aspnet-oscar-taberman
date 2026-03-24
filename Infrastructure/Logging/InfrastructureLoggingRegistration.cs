using Application.Abstractions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Logging;

public static class InfrastructureLoggingRegistration
{
    public static IServiceCollection AddLogging(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<ILogger, Logger>();

        return services;
    }
}
