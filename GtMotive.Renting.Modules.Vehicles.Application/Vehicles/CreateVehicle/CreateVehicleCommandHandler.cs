using GtMotive.Renting.Common.Application.Caching;
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(

    IVehicleRepository vehicleRepository,

    ICacheService cacheService

) : ICommandHandler<CreateVehicleCommand, Guid>
{
    private readonly string VEHICLES_KEY = "vehicles";

    public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        Result<Vehicle> vehicle = Vehicle.Create(
            request.CategoryId,
            request.YearOfManufacture,
            request.Brand,
            request.LicensePlate
        );

        if (vehicle.IsFailure)
        {
            return Result.Failure<Guid>(vehicle.Error);
        }

        await vehicleRepository.InsertVehicle(vehicle.Value);

        var cachedVehicles = await cacheService.GetAsync<List<Vehicle>>(VEHICLES_KEY, cancellationToken) ?? [];

        cachedVehicles.Add(vehicle.Value);

        await cacheService.SetAsync(
            VEHICLES_KEY,
            cachedVehicles,
            cancellationToken: cancellationToken);

        return vehicle.Value.Id;
    }
}