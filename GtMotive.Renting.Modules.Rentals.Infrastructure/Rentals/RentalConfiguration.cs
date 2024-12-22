using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Renting.Modules.Rentals.Infrastructure.Rentals;

internal sealed class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
