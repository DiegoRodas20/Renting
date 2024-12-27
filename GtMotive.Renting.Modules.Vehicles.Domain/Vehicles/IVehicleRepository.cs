namespace GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetVehicles();

    Task<Vehicle?> GetVehicleById(Guid vehicleId);

    Task InsertVehicle(Vehicle vehicle);

    Task UpdateVehicle(Guid vehicleId, VehicleStatus status);
}