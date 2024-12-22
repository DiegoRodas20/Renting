using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.EndRental;

public sealed record EndRentalCommand(

    Guid RentalId

) : ICommand<Guid>;
