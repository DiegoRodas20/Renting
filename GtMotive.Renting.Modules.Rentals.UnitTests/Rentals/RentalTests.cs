using FluentAssertions;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.UnitTests.Abstractions;
using GtMotive.Renting.Modules.Vehicles.PublicApi;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace GtMotive.Renting.Modules.Rentals.UnitTests.Rentals;

public class RentalTests : BaseTest
{
    private readonly ISender sender;

    public RentalTests()
    {
        UpdateServiceProvider(services =>
        {
            var rentalRepository = Substitute.For<IRentalRepository>();
            var vehiclesApi = Substitute.For<IVehiclesApi>();

            vehiclesApi
                .ValidateVehicleStatus(
                    Arg.Any<Guid>(),
                    Arg.Any<CancellationToken>())
                .Returns(new ValidateVehicleStatusResponse(Guid.NewGuid(), true));

            rentalRepository
                .ValidateCustomerForRental(
                    Arg.Any<Guid>(),
                    Arg.Any<DateTime>(),
                    Arg.Any<DateTime>())
                .Returns(false);

            services.AddSingleton(rentalRepository);
            services.AddSingleton(vehiclesApi);
        });

        sender = ServiceProvider.GetRequiredService<ISender>();
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenEndDatePrecedesStartDate()
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow;
        DateTime endDate = startDate.AddMinutes(-1);

        // Act
        Result<Rental> result = Rental.Create(
            Guid.NewGuid(),
            Guid.NewGuid(),
            startDate,
            endDate);

        // Assert
        result.Error.Should().Be(RentalErrors.EndDatePrecedesStartDate);
    }

    [Fact]
    public void Create_ShouldRaiseDomainEvent_WhenRentalCreated()
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow;
        DateTime endDate = startDate.AddMinutes(1);

        // Act
        Result<Rental> result = Rental.Create(
            Guid.NewGuid(),
            Guid.NewGuid(),
            startDate,
            endDate);

        Rental rental = result.Value;

        // Assert
        RentalStartedDomainEvent domainEvent = AssertDomainEventWasPublished<RentalStartedDomainEvent>(rental);

        domainEvent.RentalId.Should().Be(rental.Id);
    }

    [Fact]
    public async Task Should_CreateRental_WhenCommandIsValid()
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow;
        DateTime endDate = startDate.AddMinutes(1);

        var command = new StartRentalCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            startDate,
            endDate
        );

        // Act
        Result<Guid> result = await sender.Send(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}
