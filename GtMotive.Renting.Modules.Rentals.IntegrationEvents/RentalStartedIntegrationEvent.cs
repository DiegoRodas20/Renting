using GtMotive.Renting.Common.Application.EventBus;

namespace GtMotive.Renting.Modules.Rentals.IntegrationEvents;

public sealed class RentalStartedIntegrationEvent(

    Guid id,

    DateTime occurredOnUtc,

    Guid rentalId,

    Guid vehicleId

) : IntegrationEvent(id, occurredOnUtc)
{
    public Guid RentalId { get; init; } = rentalId;

    public Guid VehicleId { get; init; } = vehicleId;
}
