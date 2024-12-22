using GtMotive.Renting.Modules.Vehicles.Domain.Categories;
using GtMotive.Renting.Modules.Vehicles.Domain.Vehicles;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Categories;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;

public sealed class VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : DbContext(options)
{
    internal DbSet<Category> Categories { get; set; }

    internal DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Vehicles);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}