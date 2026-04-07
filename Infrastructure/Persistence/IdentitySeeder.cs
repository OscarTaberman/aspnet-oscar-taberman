using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);


        var userManager = serviceProvider.GetRequiredService<UserManager<Identity.ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await SeedRolesAsync(roleManager);
        await SeedAdminAsync(userManager);
        await SeedEmployeeAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = ["Admin", "Employee", "Member"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedAdminAsync(UserManager<Identity.ApplicationUser> userManager)
    {
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
    }

    private static async Task SeedEmployeeAsync(UserManager<Identity.ApplicationUser> userManager)
    {
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