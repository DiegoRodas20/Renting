using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;

internal sealed class RentalRepository : IRentalRepository
{
    public Task<List<Rental>> GetRentals()
    {
        throw new NotImplementedException();
    }

    public Task StartRental(Rental rental)
    {
        throw new NotImplementedException();
    }

    public Task EndRental(Guid rentalId)
    {
        throw new NotImplementedException();
    }
}