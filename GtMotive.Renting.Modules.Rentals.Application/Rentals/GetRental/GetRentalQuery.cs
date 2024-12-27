using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRental;

public sealed record GetRentalQuery(Guid RentalId) : IQuery<Rental>;