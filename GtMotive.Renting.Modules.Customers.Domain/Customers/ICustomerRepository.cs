namespace GtMotive.Renting.Modules.Customers.Domain.Customers;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomers();

    Task InsertCustomer(Customer rental);
}
