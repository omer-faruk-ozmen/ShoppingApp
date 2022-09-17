using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
