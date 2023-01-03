using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Customer;

public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}