namespace GtMotive.Renting.Modules.Rentals.Domain.Rentals;

public interface IRentalRepository
{
    Task<List<Rental>> GetRentals();

    Task<Rental?> GetRentalById(Guid rentalId);

    Task StartRental(Rental rental);

    Task EndRental(Rental rental);

    Task<bool> ValidateCustomerForRental(Guid customerId, DateTime startDate, DateTime endDate);
}
