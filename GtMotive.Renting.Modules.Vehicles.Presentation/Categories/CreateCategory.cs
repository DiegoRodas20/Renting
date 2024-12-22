using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Vehicles.Application.Categories.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Vehicles.Presentation.Categories;

internal sealed class CreateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (CreateCategoryCommand request, ISender sender) =>
        {
            var result = await sender.Send(request);

            return result;

        }).WithTags(Tags.Categories);
    }
}
