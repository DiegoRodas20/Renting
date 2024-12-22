using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentals;

public sealed record GetRentalsQuery : IQuery<IReadOnlyCollection<Rental>>;