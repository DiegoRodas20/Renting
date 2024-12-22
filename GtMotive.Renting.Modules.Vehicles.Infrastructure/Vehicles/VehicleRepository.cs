using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Vehicles;

internal sealed class VehicleRepository : IVehicleRepository
{
    public Task<List<Vehicle>> GetVehicles()
    {
        throw new NotImplementedException();
    }

    public Task InsertVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
}