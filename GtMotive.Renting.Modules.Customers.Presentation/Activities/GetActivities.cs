using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Customers.Application.Activities.GetActivities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Customers.Presentation.Activities;

internal sealed class GetActivities : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("activities", async (ISender sender) =>
        {
            var result = await sender.Send(new GetActivitiesQuery());

            return result;

        }).WithTags(Tags.Activities)
        .ExcludeFromDescription();
    }
}