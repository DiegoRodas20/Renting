using GtMotive.Renting.Common.Application.EventBus;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.IntegrationEvents;
using GtMotive.Renting.Modules.Vehicles.Application.Vehicles.UpdateVehicle;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using MediatR;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Vehicles;

internal sealed class RentalStartedIntegrationEventHandler(

    ISender sender

) : IntegrationEventHandler<RentalStartedIntegrationEvent>
{
    public override async Task Handle(RentalStartedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        var command = new UpdateVehicleCommand(
            integrationEvent.VehicleId,
            VehicleStatus.Rented
        );

        Result result = await sender.Send(command, cancellationToken);

        return result;
    }
}