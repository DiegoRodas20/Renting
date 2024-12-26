using GtMotive.Renting.Common.Domain;

namespace GtMotive.Renting.Modules.Rentals.Domain.Rentals;

public static class RentalErrors
{
    public static Error NotFoundVehicle(Guid vehicleId) =>
        Error.NotFound("Rentals.NotFoundVehicle", $"The vehicle with the identifier {vehicleId} was not found");

    public static Error NotValidVehicleStatus(Guid vehicleId) =>
        Error.Problem("Rentals.NotValidVehicleStatus", $"The vehicle with the identifier {vehicleId} does not have a valid status");

    public static Error CustomerHasActiveReservation(Guid customerId) =>
        Error.Problem("Rentals.CustomerHasActiveReservation", $"The customer with the identifier {customerId} already has an active reservation.");

}