using GtMotive.Renting.Modules.Customers.Infrastructure.Database;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Database;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<CustomersDbContext>(scope);
        ApplyMigration<RentalsDbContext>(scope);
        ApplyMigration<VehiclesDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
