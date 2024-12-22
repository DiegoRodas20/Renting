using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Vehicles.Application.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Categories;

internal sealed class GetCategories : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCategoriesQuery());

            return result;

        }).WithTags(Tags.Categories);
    }
}
