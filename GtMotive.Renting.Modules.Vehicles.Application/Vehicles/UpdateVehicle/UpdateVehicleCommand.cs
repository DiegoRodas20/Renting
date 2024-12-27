
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.UpdateVehicle;

public sealed record UpdateVehicleCommand(

    Guid VehicleId,

    VehicleStatus Status

) : ICommand;
