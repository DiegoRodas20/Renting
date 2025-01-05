using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentalById;

public sealed record GetRentalByIdQuery(Guid RentalId) : IQuery<Rental>;