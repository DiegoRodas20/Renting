using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.Domain.Reservations;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;
using GtMotive.Renting.Modules.Rentals.Infrastructure.Reservations;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Database;

public sealed class RentalsDbContext(DbContextOptions<RentalsDbContext> options) : DbContext(options)
{
    internal DbSet<Rental> Rentals { get; set; }

    internal DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Rentals);

        modelBuilder.ApplyConfiguration(new RentalConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }
}