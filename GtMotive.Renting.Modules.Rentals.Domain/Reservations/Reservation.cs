namespace GtMotive.Renting.Modules.Rentals.Domain.Reservations;

public class Reservation
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public Guid VehicleId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public ReservationStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Reservation Create(
        Guid customerId,
        Guid vehicleId,
        DateTime startDate,
        DateTime endDate)
    {
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            VehicleId = vehicleId,
            StartDate = startDate,
            EndDate = endDate,
            Status = ReservationStatus.Confirmed,
            CreatedAt = DateTime.UtcNow
        };

        return reservation;
    }
}