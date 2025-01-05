using FluentValidation;

namespace GtMotive.Renting.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(c => c.YearOfManufacture).NotEmpty();
        RuleFor(c => c.Brand).NotEmpty();
        RuleFor(c => c.LicensePlate).NotEmpty();
    }
}