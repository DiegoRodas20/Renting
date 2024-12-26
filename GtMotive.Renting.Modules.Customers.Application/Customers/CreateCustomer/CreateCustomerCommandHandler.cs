using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Customers.Domain.Customers;

namespace GtMotive.Renting.Modules.Customers.Application.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler(

    ICustomerRepository customerRepository

) : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Age
        );

        await customerRepository.InsertCustomer(customer);

        return customer.Id;
    }
}
