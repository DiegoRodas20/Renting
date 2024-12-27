namespace GtMotive.Renting.Common.Domain;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}