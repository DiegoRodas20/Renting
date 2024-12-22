namespace GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

public class Vehicle
{
    public Guid Id { get; private set; }

    public Guid CategoryId { get; private set; }

    public int YearOfManufacture { get; private set; }

    public string Brand { get; private set; } = string.Empty;

    public string LicensePlate { get; private set; } = string.Empty;

    public VehicleStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Vehicle Create(
        Guid categoryId,
        int yearOfManufacture,
        string brand,
        string licensePlate)
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            CategoryId = categoryId,
            YearOfManufacture = yearOfManufacture,
            Brand = brand,
            LicensePlate = licensePlate,
            Status = VehicleStatus.Available,
            CreatedAt = DateTime.Now,
        };

        return vehicle;
    }
}
