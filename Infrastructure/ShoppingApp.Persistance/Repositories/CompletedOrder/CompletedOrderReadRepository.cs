using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.CompletedOrder;

public class CompletedOrderReadRepository : ReadRepository<Domain.Entities.CompletedOrder>,ICompletedOrderReadRepository
{
    public CompletedOrderReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}