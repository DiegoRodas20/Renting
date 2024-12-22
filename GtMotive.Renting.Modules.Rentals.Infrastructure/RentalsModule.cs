using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Database;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure;

public static class RentalsModule
{
    public static IServiceCollection AddRentalModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RentalsDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("Database"),
                npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    Schemas.Rentals)));

        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
    }
}
