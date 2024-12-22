using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Rentals.Application.Reservations.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Rentals.Presentation.Reservations;

internal sealed class CreateReservation : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("reservations", async (CreateReservationCommand createReservationCommand, ISender sender) =>
        {
            var result = await sender.Send(createReservationCommand);

            return result;

        }).WithTags(Tags.Reservations);
    }
}
