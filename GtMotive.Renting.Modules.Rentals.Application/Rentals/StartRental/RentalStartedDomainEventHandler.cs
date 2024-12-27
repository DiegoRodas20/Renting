using GtMotive.Renting.Common.Application.EventBus;
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRental;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.IntegrationEvents;
using MediatR;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

internal sealed class RentalStartedDomainEventHandler(

    ISender sender,

    IEventBus eventBus

) : DomainEventHandler<RentalStartedDomainEvent>
{
    public override async Task Handle(RentalStartedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Result<Rental> result = await sender.Send(new GetRentalQuery(domainEvent.RentalId), cancellationToken);

        if (result.IsFailure)
        {
            return;
        }

        var integrationEvent = new RentalStartedIntegrationEvent(
            domainEvent.Id,
            domainEvent.OccurredOnUtc,
            result.Value.Id,
            result.Value.VehicleId
        );

        await eventBus.PublishAsync(integrationEvent, cancellationToken);
    }
}