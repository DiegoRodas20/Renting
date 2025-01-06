using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Vehicles.Application.Categories.GetCategories;
using GtMotive.Renting.Modules.Vehicles.Domain.Categories;
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
            Result<IReadOnlyCollection<Category>> result = await sender.Send(new GetCategoriesQuery());

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Categories);
    }
}
