using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Customers.Domain.Customers;

namespace GtMotive.Renting.Modules.Customers.Application.Customers.GetCustomers;

internal sealed class GetCustomersQueryHandler(

    ICustomerRepository customerRepository

) : IQueryHandler<GetCustomersQuery, IReadOnlyCollection<Customer>>
{
    public async Task<Result<IReadOnlyCollection<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        List<Customer> result = await customerRepository.GetCustomers();

        return result;
    }
}