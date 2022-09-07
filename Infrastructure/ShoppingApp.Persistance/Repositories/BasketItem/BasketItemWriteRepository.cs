using ShoppingApp.Application.Repositories.BasketItem;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.BasketItem;

public class BasketItemWriteRepository : WriteRepository<Domain.Entities.BasketItem>, IBasketItemWriteRepository
{
    public BasketItemWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}