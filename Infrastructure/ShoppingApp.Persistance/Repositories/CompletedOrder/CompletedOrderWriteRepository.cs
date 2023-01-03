using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.CompletedOrder;

public class CompletedOrderWriteRepository : WriteRepository<Domain.Entities.CompletedOrder>,ICompletedOrderWriteRepository
{
    public CompletedOrderWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}