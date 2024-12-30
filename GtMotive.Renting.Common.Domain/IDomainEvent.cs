using MediatR;

namespace GtMotive.Renting.Common.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}