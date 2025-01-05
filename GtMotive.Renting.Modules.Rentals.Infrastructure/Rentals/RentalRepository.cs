using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;

internal sealed class RentalRepository(RentalsDbContext context) : IRentalRepository
{
    public async Task<List<Rental>> GetRentals()
    {
        return await context.Rentals.ToListAsync();
    }

    public async Task<Rental?> GetRentalById(Guid rentalId)
    {
        return await context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
    }

    public async Task StartRental(Rental rental)
    {
        await context.Rentals.AddAsync(rental);
        await context.SaveChangesAsync();
    }

    public async Task EndRental(Rental rental)
    {
        await context.SaveChangesAsync();
    }

    public async Task<bool> ValidateCustomerForRental(Guid customerId, DateTime startDate, DateTime endDate)
    {
        var conflictingRentals = await context.Rentals.Where(
            value => value.CustomerId == customerId &&
                     value.Status == RentalStatus.Active &&
                     (
                        (startDate >= value.StartDate && startDate <= value.EndDate) ||
                        (endDate >= value.StartDate && endDate <= value.EndDate) ||
                        (startDate <= value.StartDate && endDate >= value.EndDate)
                     )
        ).ToListAsync();

        return !(conflictingRentals.Count == 0);
    }
}