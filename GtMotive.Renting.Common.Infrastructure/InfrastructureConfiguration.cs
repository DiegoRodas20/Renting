using GtMotive.Renting.Common.Application.Caching;
using GtMotive.Renting.Common.Application.EventBus;
using GtMotive.Renting.Common.Infrastructure.Caching;
using GtMotive.Renting.Common.Infrastructure.EventBus;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

namespace GtMotive.Renting.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        RabbitMqSettings rabbitMqSettings,
        string redisConnectionString)
    {
        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.AddSingleton(connectionMultiplexer);
            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        services.AddMassTransit(configure =>
        {
            foreach (Action<IRegistrationConfigurator> configureConsumers in moduleConfigureConsumers)
            {
                configureConsumers(configure);
            }

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(rabbitMqSettings.Host), h =>
                {
                    h.Username(rabbitMqSettings.Username);
                    h.Password(rabbitMqSettings.Password);
                });

                config.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
