using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentalById;

internal sealed class GetRentalByIdQueryHandler(

    IRentalRepository rentalRepository

) : IQueryHandler<GetRentalByIdQuery, Rental>
{
    public async Task<Result<Rental>> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
    {
        Rental? rental = await rentalRepository.GetRentalById(request.RentalId);

        if (rental is null)
        {
            return Result.Failure<Rental>(RentalErrors.NotFound(request.RentalId));
        }

        return rental;
    }
}
