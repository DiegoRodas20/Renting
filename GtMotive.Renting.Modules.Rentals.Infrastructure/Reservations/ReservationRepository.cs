using GtMotive.Renting.Modules.Rentals.Domain.Reservations;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Reservations;

internal sealed class ReservationRepository : IReservationRepository
{
    public Task<List<Reservation>> GetReservations()
    {
        throw new NotImplementedException();
    }

    public Task InsertReservation(Reservation rental)
    {
        throw new NotImplementedException();
    }
}
