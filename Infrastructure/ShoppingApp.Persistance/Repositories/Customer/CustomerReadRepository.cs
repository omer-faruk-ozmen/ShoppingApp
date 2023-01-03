using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Customer;

public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}