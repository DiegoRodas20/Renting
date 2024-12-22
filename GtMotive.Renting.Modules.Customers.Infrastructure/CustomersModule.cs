using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Customers.Domain.Activities;
using GtMotive.Renting.Modules.Customers.Domain.Customers;
using GtMotive.Renting.Modules.Customers.Infrastructure.Activities;
using GtMotive.Renting.Modules.Customers.Infrastructure.Customers;
using GtMotive.Renting.Modules.Customers.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Renting.Modules.Customers.Infrastructure;

public static class CustomersModule
{
    public static IServiceCollection AddCustomerModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomersDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("Database"),
                npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    Schemas.Customers)));

        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}
