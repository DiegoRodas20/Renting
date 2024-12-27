using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRental;

internal sealed class GetRentalQueryHandler(

    IRentalRepository rentalRepository

) : IQueryHandler<GetRentalQuery, Rental>
{
    public async Task<Result<Rental>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
    {
        Rental? rental = await rentalRepository.GetRental(request.RentalId);

        if (rental is null)
        {
            return Result.Failure<Rental>(RentalErrors.NotFound(request.RentalId));
        }

        return rental;
    }
}
