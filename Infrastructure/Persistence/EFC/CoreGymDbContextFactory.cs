using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.EFC;

// Factory to direct EF Core where to build DbContext (CoreGymDbContext)
public sealed class CoreGymDbContextFactory : IDesignTimeDbContextFactory<CoreGymDbContext>
{
    public CoreGymDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoreGymDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost,1433;User ID=sa;Password=Str0ng!Passw0rd;Database=CoreGymDb;TrustServerCertificate=True;");

        return new CoreGymDbContext(optionsBuilder.Options);
    }
}
