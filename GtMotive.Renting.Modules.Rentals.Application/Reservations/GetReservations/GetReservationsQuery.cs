using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;

namespace GtMotive.Renting.Modules.Rentals.Application.Reservations.GetReservations;

public sealed record GetReservationsQuery : IQuery<IReadOnlyCollection<Reservation>>;