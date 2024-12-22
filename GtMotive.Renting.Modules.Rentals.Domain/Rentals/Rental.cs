namespace GtMotive.Renting.Modules.Rentals.Domain.Rentals;

public class Rental
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public Guid VehicleId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public RentalStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Rental Create(
        Guid customerId,
        Guid vehicleId,
        DateTime startDate,
        DateTime endDate)
    {
        var rental = new Rental
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            VehicleId = vehicleId,
            StartDate = startDate,
            EndDate = endDate,
            Status = RentalStatus.Active,
            CreatedAt = DateTime.UtcNow
        };

        return rental;
    }
}
