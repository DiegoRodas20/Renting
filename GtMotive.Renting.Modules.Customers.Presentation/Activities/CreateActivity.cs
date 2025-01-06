using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Customers.Application.Activities.CreateActivity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Customers.Presentation.Activities;

internal sealed class CreateActivity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("activities", async (CreateActivityCommand createReservationCommand, ISender sender) =>
        {
            var result = await sender.Send(createReservationCommand);

            return result;

        }).WithTags(Tags.Activities)
        .ExcludeFromDescription();
    }
}