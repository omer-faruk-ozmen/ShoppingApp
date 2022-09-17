using ShoppingApp.Application.Repositories.Basket;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Basket;

public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
{
    public BasketReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}