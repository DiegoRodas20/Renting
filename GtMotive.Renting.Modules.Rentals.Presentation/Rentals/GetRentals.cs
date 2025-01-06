using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentals;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Rentals.Presentation.Rentals;

internal sealed class GetRentals : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("rentals", async (ISender sender) =>
        {
            var result = await sender.Send(new GetRentalsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Rentals);
    }
}