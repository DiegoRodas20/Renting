using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Rentals.Application.Reservations.GetReservations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Rentals.Presentation.Reservations;

internal sealed class GetReservations : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("reservations", async (ISender sender) =>
        {
            var result = await sender.Send(new GetReservationsQuery());

            return result;

        }).WithTags(Tags.Reservations);
    }
}
