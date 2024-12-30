using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Vehicles.Domain.Categories;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Categories;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.PublicApi;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Vehicles;
using GtMotive.Renting.Modules.Vehicles.Presentation.Vehicles;
using GtMotive.Renting.Modules.Vehicles.PublicApi;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure;

public static class VehiclesModule
{
    public static IServiceCollection AddVehicleModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehiclesDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("Database"),
                npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    Schemas.Vehicles)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehiclesApi, VehiclesApi>();
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<RentalStartedIntegrationEventHandler>();
    }
}
