using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;

namespace GtMotive.Renting.Modules.Rentals.Application.Reservations.CreateReservation;

internal sealed class CreateReservationCommandHandler(

    IReservationRepository reservationRepository

) : ICommandHandler<CreateReservationCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = Reservation.Create(
            request.CustomerId,
            request.VehicleId,
            request.StartDate,
            request.EndDate
        );

        await reservationRepository.InsertReservation(reservation);

        return reservation.Id;
    }
}
