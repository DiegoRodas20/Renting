using GtMotive.Renting.Modules.Customers.Domain.Customers;
using GtMotive.Renting.Modules.Customers.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Customers.Infrastructure.Customers;

internal sealed class CustomerRepository(CustomersDbContext context) : ICustomerRepository
{
    public async Task<List<Customer>> GetCustomers()
    {
        var customers = await context.Customers.ToListAsync();

        return customers;
    }

    public async Task InsertCustomer(Customer customer)
    {
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
    }
}
