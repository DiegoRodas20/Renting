namespace GtMotive.Renting.Modules.Vehicles.PublicApi;

public interface IVehiclesApi
{
    Task<ValidateVehicleStatusResponse?> ValidateVehicleStatus(Guid vehicleId, CancellationToken cancellationToken = default);
}
