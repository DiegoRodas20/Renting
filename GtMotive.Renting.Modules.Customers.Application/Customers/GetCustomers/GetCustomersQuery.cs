using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Customers.Domain.Customers;

namespace GtMotive.Renting.Modules.Customers.Application.Customers.GetCustomers;

public sealed record GetCustomersQuery : IQuery<IReadOnlyCollection<Customer>>;
