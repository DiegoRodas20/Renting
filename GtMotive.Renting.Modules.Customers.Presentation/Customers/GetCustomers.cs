using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Modules.Customers.Application.Customers.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Customers.Presentation.Customers;

internal sealed class GetCustomers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("customers", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersQuery());

            return result;

        }).WithTags(Tags.Customers);
    }
}