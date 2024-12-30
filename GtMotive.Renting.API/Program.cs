using GtMotive.Renting.API.Extensions;
using GtMotive.Renting.Common.Application;
using GtMotive.Renting.Common.Infrastructure;
using GtMotive.Renting.Common.Infrastructure.Configuration;
using GtMotive.Renting.Common.Infrastructure.EventBus;
using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Customers.Infrastructure;
using GtMotive.Renting.Modules.Rentals.Infrastructure;
using GtMotive.Renting.Modules.Vehicles.Infrastructure;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Assembly[] moduleApplicationAssemblues = [
    GtMotive.Renting.Modules.Customers.Application.AssemblyReference.Assembly,
    GtMotive.Renting.Modules.Rentals.Application.AssemblyReference.Assembly,
    GtMotive.Renting.Modules.Vehicles.Application.AssemblyReference.Assembly,
];

builder.Services.AddApplication(moduleApplicationAssemblues);

string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");
RabbitMqSettings rabbitMqSettings = new(builder.Configuration.GetConnectionStringOrThrow("Queue"));

builder.Services.AddInfrastructure(
    [
        VehiclesModule.ConfigureConsumers
    ],
    rabbitMqSettings,
    redisConnectionString
);

// Modules
builder.Services.AddCustomerModule(builder.Configuration);
builder.Services.AddRentalModule(builder.Configuration);
builder.Services.AddVehicleModule(builder.Configuration);

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapEndpoints();

app.Run();
