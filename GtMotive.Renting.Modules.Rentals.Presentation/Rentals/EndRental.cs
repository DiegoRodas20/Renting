using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.EndRental;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Rentals.Presentation.Rentals;

internal sealed class EndRental : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("rentals/{id}/end", async (Guid id, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new EndRentalCommand(id));

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Rentals);
    }
}