using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

internal sealed class StartRentalCommandHandler(

    IRentalRepository rentalRepository

) : ICommandHandler<StartRentalCommand, Guid>
{
    public async Task<Result<Guid>> Handle(StartRentalCommand request, CancellationToken cancellationToken)
    {
        var rental = Rental.Create(
            request.CustomerId,
            request.VehicleId,
            request.StartDate,
            request.EndDate
        );

        await rentalRepository.StartRental(rental);

        return rental.Id;
    }
}