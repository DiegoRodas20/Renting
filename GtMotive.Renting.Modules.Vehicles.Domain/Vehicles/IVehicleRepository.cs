namespace GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetVehicles();

    Task InsertVehicle(Vehicle vehicle);
}