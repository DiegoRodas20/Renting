using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.EndRental;

internal sealed class EndRentalCommandHandler(

    IRentalRepository rentalRepository

) : ICommandHandler<EndRentalCommand, Guid>
{
    public async Task<Result<Guid>> Handle(EndRentalCommand request, CancellationToken cancellationToken)
    {
        await rentalRepository.EndRental(request.RentalId);

        return request.RentalId;
    }
}