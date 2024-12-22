using GtMotive.Renting.Modules.Customers.Domain.Customers;

namespace GtMotive.Renting.Modules.Customers.Infrastructure.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    public Task<List<Customer>> GetCustomers()
    {
        throw new NotImplementedException();
    }

    public Task InsertCustomer(Customer rental)
    {
        throw new NotImplementedException();
    }
}
