using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;

namespace GtMotive.Renting.Modules.Rentals.Application.Reservations.GetReservations;

internal sealed class GetReservationsQueryHandler(

    IReservationRepository reservationRepository

) : IQueryHandler<GetReservationsQuery, IReadOnlyCollection<Reservation>>
{
    public async Task<Result<IReadOnlyCollection<Reservation>>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        List<Reservation> result = await reservationRepository.GetReservations();

        return result;
    }
}
