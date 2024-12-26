using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Common.Presentation.Endpoints;
using GtMotive.Renting.Common.Presentation.Results;
using GtMotive.Renting.Modules.Customers.Application.Customers.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Modules.Customers.Presentation.Customers;

internal sealed class CreateCustomer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("customers", async (CreateCustomerCommand createCustomerCommand, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(createCustomerCommand);

            return result.Match(Results.Ok, ApiResults.Problem);

        }).WithTags(Tags.Customers);
    }
}