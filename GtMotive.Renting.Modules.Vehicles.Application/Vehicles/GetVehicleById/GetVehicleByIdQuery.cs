using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicleById;

public sealed record GetVehicleByIdQuery(

    Guid VehicleId

) : IQuery<Vehicle>;