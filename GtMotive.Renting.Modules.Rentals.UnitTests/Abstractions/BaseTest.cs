using Bogus;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GtMotive.Renting.Modules.Rentals.UnitTests.Abstractions;

public abstract class BaseTest
{
    protected IServiceProvider ServiceProvider { get; private set; }

    protected static readonly Faker Faker = new();

    private readonly ServiceCollection services;

    protected BaseTest()
    {
        services = [];

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(AssemblyReference.Assembly);
        });

        ServiceProvider = services.BuildServiceProvider();
    }

    protected void UpdateServiceProvider(Action<IServiceCollection> configureServices)
    {
        configureServices(services);

        ServiceProvider = services.BuildServiceProvider();
    }

    public static T AssertDomainEventWasPublished<T>(Entity entity)
        where T : IDomainEvent
    {
        T? domainEvent = entity.DomainEvents.OfType<T>().SingleOrDefault();

        if (domainEvent is null)
        {
            throw new Exception($"{typeof(T).Name} was not published");
        }

        return domainEvent;
    }
}
