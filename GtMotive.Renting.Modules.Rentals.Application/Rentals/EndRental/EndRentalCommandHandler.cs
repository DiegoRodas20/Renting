using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.EndRental;

internal sealed class EndRentalCommandHandler(

    IRentalRepository rentalRepository

) : ICommandHandler<EndRentalCommand, Guid>
{
    public async Task<Result<Guid>> Handle(EndRentalCommand request, CancellationToken cancellationToken)
    {
        Rental? rental = await rentalRepository.GetRentalById(request.RentalId);

        if (rental is null)
        {
            return Result.Failure<Guid>(RentalErrors.NotFound(request.RentalId));
        }

        Result result = rental.End();

        await rentalRepository.EndRental(rental);

        return request.RentalId;
    }
}