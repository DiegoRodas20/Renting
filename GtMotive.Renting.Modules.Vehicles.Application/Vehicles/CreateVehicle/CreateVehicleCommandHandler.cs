using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(

    IVehicleRepository vehicleRepository

) : ICommandHandler<CreateVehicleCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = Vehicle.Create(
            request.CategoryId,
            request.YearOfManufacture,
            request.Brand,
            request.LicensePlate
        );

        await vehicleRepository.InsertVehicle(vehicle);

        return vehicle.Id;
    }
}