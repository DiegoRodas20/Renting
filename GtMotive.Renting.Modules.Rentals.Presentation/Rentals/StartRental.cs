using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Rentals.Presentation.Rentals;

internal sealed class StartRental : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("rentals", async (StartRentalCommand startRentalCommand, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(startRentalCommand);

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Rentals);
    }
}