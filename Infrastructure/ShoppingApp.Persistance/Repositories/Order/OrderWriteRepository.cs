using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Order;

public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}