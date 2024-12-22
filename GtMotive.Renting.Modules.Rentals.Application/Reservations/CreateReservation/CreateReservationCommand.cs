using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Rentals.Application.Reservations.CreateReservation;

public sealed record CreateReservationCommand(

    Guid CustomerId,

    Guid VehicleId,

    DateTime StartDate,

    DateTime EndDate

) : ICommand<Guid>;
