using GtMotive.Renting.Modules.Rentals.Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Renting.Modules.Rentals.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
public abstract class BaseIntegrationTest : IDisposable
{
    private readonly IServiceScope _serviceScope;
    protected readonly ISender _sender;
    protected readonly RentalsDbContext _context;
    protected readonly HttpClient _httpClient;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();
        _httpClient = factory.CreateClient();
        _sender = _serviceScope.ServiceProvider.GetRequiredService<ISender>();
        _context = _serviceScope.ServiceProvider.GetRequiredService<RentalsDbContext>();
    }

    public void Dispose()
    {
        _serviceScope.Dispose();
    }
}