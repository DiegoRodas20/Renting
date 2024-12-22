using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.CreateVehicle;

public sealed record CreateVehicleCommand(

    Guid CategoryId,

    int YearOfManufacture,

    string Brand,

    string LicensePlate

): ICommand<Guid>;
