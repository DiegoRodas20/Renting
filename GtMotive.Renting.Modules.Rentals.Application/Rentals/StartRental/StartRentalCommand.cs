using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

public sealed record StartRentalCommand(

    Guid CustomerId,

    Guid VehicleId,

    DateTime StartDate,

    DateTime EndDate

) : ICommand;
