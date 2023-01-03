using ShoppingApp.Application.Repositories.Menu;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Menu;

public class MenuReadRepository:ReadRepository<Domain.Entities.Menu>,IMenuReadRepository
{
    public MenuReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}