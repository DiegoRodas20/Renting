using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicles;

internal sealed class GetVehiclesQueryHandler(

    IVehicleRepository vehicleRepository

) : IQueryHandler<GetVehiclesQuery, IReadOnlyCollection<Vehicle>>
{
    public async Task<Result<IReadOnlyCollection<Vehicle>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        List<Vehicle> result = await vehicleRepository.GetVehicles();

        return result;
    }
}