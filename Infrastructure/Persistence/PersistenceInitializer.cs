using Infrastructure.Persistence.EFC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence;

public static class PersistenceInitializer
{
    public static async Task InitializerAsync(IServiceProvider serviceProvider, IHostEnvironment environment, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        ArgumentNullException.ThrowIfNull(environment);

        using var scope = serviceProvider.CreateScope();
    }
}
