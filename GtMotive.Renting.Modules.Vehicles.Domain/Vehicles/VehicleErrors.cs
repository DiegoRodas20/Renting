using GtMotive.Renting.Common.Domain;

namespace GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

public static class VehicleErrors
{
    public static readonly Error InvalidYearOfManufacture = Error.Problem(
        "Vehicles.InvalidYearOfManufacture",
        "The vehicle's year of manufacture must not be older than 5 years.");

    public static readonly Error NotFoundCategory = Error.Problem(
        "Vehicles.NotFoundCategory",
        "The category was not found.");
}