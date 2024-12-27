using GtMotive.Renting.Common.Application.EventBus;
using GtMotive.Renting.Common.Infrastructure.Inbox;
using GtMotive.Renting.Common.Infrastructure.Serialization;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;
using MassTransit;
using Newtonsoft.Json;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Inbox;

internal class IntegrationEventConsumer<TIntegrationEvent>(

    VehiclesDbContext context

) : IConsumer<TIntegrationEvent> where TIntegrationEvent : IntegrationEvent
{
    public async Task Consume(ConsumeContext<TIntegrationEvent> context)
    {
        TIntegrationEvent integrationEvent = context.Message;

        var inboxMessage = new InboxMessage
        {
            Id = integrationEvent.Id,
            Type = integrationEvent.GetType().Name,
            Content = JsonConvert.SerializeObject(integrationEvent, SerializerSettings.Instance),
            OccurredOnUtc = integrationEvent.OccurredOnUtc
        };

        await context.
    }
}
