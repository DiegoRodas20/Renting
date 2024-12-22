namespace GtMotive.Renting.Modules.Rentals.Domain.Reservations;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservations();

    Task InsertReservation(Reservation rental);
}
