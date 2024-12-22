using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentals;

internal sealed class GetRentalsQueryHandler(

    IRentalRepository rentalRepository

) : IQueryHandler<GetRentalsQuery, IReadOnlyCollection<Rental>>
{
    public async Task<Result<IReadOnlyCollection<Rental>>> Handle(GetRentalsQuery request, CancellationToken cancellationToken)
    {
        List<Rental> result = await rentalRepository.GetRentals();

        return result;
    }
}
