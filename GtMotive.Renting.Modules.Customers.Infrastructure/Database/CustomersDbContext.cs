using GtMotive.Renting.Modules.Customers.Domain.Activities;
using GtMotive.Renting.Modules.Customers.Domain.Customers;
using GtMotive.Renting.Modules.Customers.Infrastructure.Activities;
using GtMotive.Renting.Modules.Customers.Infrastructure.Customers;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Customers.Infrastructure.Database;

public sealed class CustomersDbContext(DbContextOptions<CustomersDbContext> options) : DbContext(options)
{
    internal DbSet<Activity> Activities { get; set; }

    internal DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Customers);

        modelBuilder.ApplyConfiguration(new ActivityConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}