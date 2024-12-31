using GtMotive.Renting.Common.Application.Caching;
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(

    IVehicleRepository vehicleRepository,

    ICacheService cacheService

) : ICommandHandler<UpdateVehicleCommand>
{
    private readonly string VEHICLES_KEY = "vehicles";

    public async Task<Result> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        await vehicleRepository.UpdateVehicle(request.VehicleId, request.Status);

        await cacheService.RemoveAsync(VEHICLES_KEY, cancellationToken);

        return Result.Success();
    }
}
