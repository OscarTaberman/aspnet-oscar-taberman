using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services;
    }
}
