using GtMotive.Renting.Modules.Rentals.IntegrationEvents;
using GtMotive.Renting.Modules.Vehicles.Application.Vehicles.UpdateVehicle;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using MassTransit;
using MediatR;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Vehicles;

public sealed class RentalStartedIntegrationEventHandler(

    ISender sender

) : IConsumer<RentalStartedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<RentalStartedIntegrationEvent> context)
    {
        var command = new UpdateVehicleCommand(
            context.Message.VehicleId,
            VehicleStatus.Rented
        );

        await sender.Send(command);
    }

    //public override async Task Handle(RentalStartedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    //{
    //    var command = new UpdateVehicleCommand(
    //        integrationEvent.VehicleId,
    //        VehicleStatus.Rented
    //    );

    //    await sender.Send(command, cancellationToken);
    //}
}