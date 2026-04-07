using Infrastructure.Identity;
using Infrastructure.Persistence.EFC;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence;

public static class InfrastructurePersistenceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(environment);

        // In development use in-memory database
        if (environment.IsDevelopment())
        {
            services.AddDbContext<CoreGymDbContext>(options =>
                options.UseInMemoryDatabase("CoreFitnessGym"));
        }
        // In production use SQL Server
        else
        {
            var connectionString = configuration.GetConnectionString("CoreGymConnection");

            services.AddDbContext<CoreGymDbContext>(options =>
                options.UseSqlServer(connectionString));
        }


        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<CoreGymDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
