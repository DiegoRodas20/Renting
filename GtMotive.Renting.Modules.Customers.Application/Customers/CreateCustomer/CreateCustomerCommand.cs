using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Customers.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(

    string FirstName,

    string LastName,

    string Email,

    string PhoneNumber

) : ICommand<Guid>;