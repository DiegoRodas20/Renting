using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicleById;

internal sealed class GetVehicleByIdQueryHandler(

    IVehicleRepository vehicleRepository

) : IQueryHandler<GetVehicleByIdQuery, Vehicle>
{
    public async Task<Result<Vehicle>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        Vehicle? result = await vehicleRepository.GetVehicleById(request.VehicleId);

        return result;
    }
}
