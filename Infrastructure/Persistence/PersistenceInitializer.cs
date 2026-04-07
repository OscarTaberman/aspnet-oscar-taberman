using Infrastructure.Persistence.EFC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence;

public static class PersistenceInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IHostEnvironment environment, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        ArgumentNullException.ThrowIfNull(environment);

        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoreGymDbContext>();

        if (environment.IsDevelopment())
        {
            await dbContext.Database.EnsureCreatedAsync(ct);

        }
        else
        {
            await dbContext.Database.MigrateAsync(ct);
        }

        await IdentitySeeder.SeedAsync(scope.ServiceProvider);
    }
}
