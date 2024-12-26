namespace GtMotive.Renting.Modules.Rentals.Domain.Rentals;

public interface IRentalRepository
{
    Task<List<Rental>> GetRentals();

    Task StartRental(Rental rental);

    Task EndRental(Guid rentalId);

    Task<bool> ValidateCustomerForRental(Guid customerId, DateTime startDate, DateTime endDate);
}
