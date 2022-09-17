using ShoppingApp.Application.Repositories.Basket;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Basket;

public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
{
    public BasketWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}