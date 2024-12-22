using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Vehicles.Application.Vehicles.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Vehicles;

internal sealed class CreateVehicle : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("vehicles", async (CreateVehicleCommand request, ISender sender) =>
        {
            var result = await sender.Send(request);

            return result;

        }).WithTags(Tags.Vehicles);
    }
}
