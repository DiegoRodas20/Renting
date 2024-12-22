using GtMotive.Renting.API.Extensions;
using GtMotive.Renting.Common.Application;
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

// Modules
builder.Services.AddCustomerModule(builder.Configuration);
builder.Services.AddRentalModule(builder.Configuration);
builder.Services.AddVehicleModule(builder.Configuration);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
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
