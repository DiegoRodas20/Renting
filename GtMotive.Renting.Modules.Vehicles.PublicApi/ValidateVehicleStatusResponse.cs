namespace GtMotive.Renting.Modules.Vehicles.PublicApi;

public sealed record ValidateVehicleStatusResponse(

    Guid Id,

    bool IsValid
);
