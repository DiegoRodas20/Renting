using System.Text.Json.Serialization;

namespace GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

public sealed class Vehicle
{
    [JsonInclude]
    public Guid Id { get; private set; }

    [JsonInclude]
    public Guid CategoryId { get; private set; }

    [JsonInclude]
    public int YearOfManufacture { get; private set; }

    [JsonInclude]
    public string Brand { get; private set; } = string.Empty;

    [JsonInclude]
    public string LicensePlate { get; private set; } = string.Empty;

    [JsonInclude]
    public VehicleStatus Status { get; private set; }

    [JsonInclude]
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
            CreatedAt = DateTime.UtcNow,
        };

        return vehicle;
    }
}
