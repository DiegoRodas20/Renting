using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicleById;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using GtMotive.Renting.Modules.Vehicles.PublicApi;
using MediatR;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.PublicApi;

internal sealed class VehiclesApi(

    ISender sender

) : IVehiclesApi
{

    public async Task<ValidateVehicleStatusResponse?> ValidateVehicleStatus(Guid vehicleId, CancellationToken cancellationToken = default)
    {

        Result<Vehicle> result = await sender.Send(new GetVehicleByIdQuery(vehicleId), cancellationToken);

        if (result.IsFailure)
        {
            return null;
        }

        if (result.Value.Status is not VehicleStatus.Available)
        {
            return new ValidateVehicleStatusResponse(
                result.Value.Id,
                false
            );
        }

        return new ValidateVehicleStatusResponse(
            result.Value.Id,
            true
        );
    }
}
