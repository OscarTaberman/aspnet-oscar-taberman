using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence;

public static class PersistenceInitializer
{
    public static async Task InitializerAsync(IServiceProvider serviceProvider, IHostEnvironment environment, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        ArgumentNullException.ThrowIfNull(environment);

        if (environment.IsDevelopment())
        {

        }
        else
        {

        }
    }
}
