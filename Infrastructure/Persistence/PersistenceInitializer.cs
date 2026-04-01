using Infrastructure.Persistence.EFC;
using Microsoft.AspNetCore.Identity;
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


        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Identity.ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = ["Admin", "Employee", "Member"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var adminEmail = "admin@coregym.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser is null)
        {
            var user = new Identity.ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "Admin",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        var employeeEmail = "employee@coregym.com";
        var employeeUser = await userManager.FindByEmailAsync(employeeEmail);

        if (employeeUser is null)
        {
            var user = new Identity.ApplicationUser
            {
                UserName = employeeEmail,
                Email = employeeEmail,
                FirstName = "Employee",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(user, "Employee@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(employeeUser, "Employee"))
            {
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }
        }
    }
}
