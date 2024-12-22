using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicles;

public sealed record GetVehiclesQuery : IQuery<IReadOnlyCollection<Vehicle>>;