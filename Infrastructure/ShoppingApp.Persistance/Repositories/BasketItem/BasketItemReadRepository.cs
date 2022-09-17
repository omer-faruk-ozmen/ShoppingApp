using ShoppingApp.Application.Repositories.BasketItem;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
{
    public BasketItemReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}