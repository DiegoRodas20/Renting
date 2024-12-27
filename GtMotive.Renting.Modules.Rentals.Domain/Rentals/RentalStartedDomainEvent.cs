using GtMotive.Renting.Common.Domain;

namespace GtMotive.Renting.Modules.Rentals.Domain.Rentals;

public sealed class RentalStartedDomainEvent(Guid rentalId) : DomainEvent
{
    public Guid RentalId { get; init; } = rentalId;
}
