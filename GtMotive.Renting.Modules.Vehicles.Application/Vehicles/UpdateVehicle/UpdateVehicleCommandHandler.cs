using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(

    IVehicleRepository vehicleRepository

) : ICommandHandler<UpdateVehicleCommand>
{
    public async Task<Result> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        await vehicleRepository.UpdateVehicle(request.VehicleId, request.Status);

        return Result.Success();
    }
}
