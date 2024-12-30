using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Reservations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Database;

public sealed class RentalsDbContext(

    DbContextOptions<RentalsDbContext> options,

    IPublisher publisher

    ) : DbContext(options)
{
    internal DbSet<Rental> Rentals { get; set; }

    internal DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Rentals);

        modelBuilder.ApplyConfiguration(new RentalConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker
                            .Entries<Entity>()
                            .Select(entry => entry.Entity)
                            .SelectMany(entity =>
                            {
                                IReadOnlyCollection<IDomainEvent> domainEvents = entity.DomainEvents;

                                entity.ClearDomainEvents();

                                return domainEvents;
                            })
                            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}