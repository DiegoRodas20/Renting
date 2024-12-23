using GtMotive.Renting.Common.Application.Caching;
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicles;

internal sealed class GetVehiclesQueryHandler(

    IVehicleRepository vehicleRepository,

    ICacheService cacheService

) : IQueryHandler<GetVehiclesQuery, IReadOnlyCollection<Vehicle>>
{
    private readonly string VEHICLES_KEY = "vehicles";

    public async Task<Result<IReadOnlyCollection<Vehicle>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        List<Vehicle>? resultCache = await cacheService.GetAsync<List<Vehicle>>(VEHICLES_KEY, cancellationToken);

        if (resultCache is not null)
        {
            return resultCache;
        }

        List<Vehicle> result = await vehicleRepository.GetVehicles();

        await cacheService.SetAsync(VEHICLES_KEY, result);

        return result;
    }
}