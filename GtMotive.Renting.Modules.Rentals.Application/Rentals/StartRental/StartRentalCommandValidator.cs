using FluentValidation;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

internal sealed class StartRentalCommandValidator : AbstractValidator<StartRentalCommand>
{
    public StartRentalCommandValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required.")
            .NotEqual(Guid.Empty)
            .WithMessage("CustomerId must be a valid GUID.");

        RuleFor(c => c.VehicleId)
            .NotEmpty()
            .WithMessage("VehicleId is required.")
            .NotEqual(Guid.Empty)
            .WithMessage("VehicleId must be a valid GUID.");
    }
}
