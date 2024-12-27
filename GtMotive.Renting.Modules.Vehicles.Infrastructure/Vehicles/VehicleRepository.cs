using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Vehicles;

internal sealed class VehicleRepository(VehiclesDbContext context) : IVehicleRepository
{
    public async Task<List<Vehicle>> GetVehicles()
    {
        var vehicles = await context.Vehicles.ToListAsync();

        return vehicles;
    }

    public async Task<Vehicle?> GetVehicleById(Guid vehicleId)
    {
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == vehicleId);

        return vehicle;
    }

    public async Task InsertVehicle(Vehicle vehicle)
    {
        await context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
    }

    public async Task UpdateVehicle(Guid vehicleId, VehicleStatus status)
    {
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == vehicleId);

        vehicle.Update(status);

        await context.SaveChangesAsync();
    }
}