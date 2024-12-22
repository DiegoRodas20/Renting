using Microsoft.AspNetCore.Routing;

namespace GtMotive.Renting.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}