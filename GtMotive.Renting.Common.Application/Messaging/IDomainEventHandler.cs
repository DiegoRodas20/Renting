using GtMotive.Renting.Common.Domain;
using MediatR;

namespace GtMotive.Renting.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;