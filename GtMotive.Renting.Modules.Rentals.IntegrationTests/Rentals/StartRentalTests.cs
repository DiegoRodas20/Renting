using FluentAssertions;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.IntegrationTests.Abstractions;
using System.Net;
using System.Net.Http.Json;

namespace GtMotive.Renting.Modules.Rentals.IntegrationTests.Rentals;

public class StartRentalTests(

    IntegrationTestWebAppFactory factory

) : BaseIntegrationTest(factory)
{

    [Fact]
    public async Task Should_ReturnNotFound_WhenRequestIsNotValid_WithoutHost()
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow;
        DateTime endDate = startDate.AddMinutes(1);
        Guid vehicleId = Guid.NewGuid();

        var request = new StartRentalCommand(
            Guid.NewGuid(),
            vehicleId,
            startDate,
            endDate
        );

        // Act
        Result<Guid> result = await _sender.Send(request);

        // Assert
        result.Error.Should().Be(RentalErrors.NotFoundVehicle(vehicleId));
    }

    [Fact]
    public async Task Should_ReturnNotFound_WhenRequestIsNotValid_WithHost()
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow;
        DateTime endDate = startDate.AddMinutes(1);

        var request = new StartRentalCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            startDate,
            endDate
        );

        // Act
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("rentals", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

}