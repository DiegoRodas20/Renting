using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Vehicles.Application.Vehicles.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Vehicles;

internal sealed class GetVehicles : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("vehicles", async (ISender sender) =>
        {
            var result = await sender.Send(new GetVehiclesQuery());

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Vehicles);
    }
}
