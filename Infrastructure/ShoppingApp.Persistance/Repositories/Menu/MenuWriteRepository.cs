using ShoppingApp.Application.Repositories.Menu;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Menu;

public class MenuWriteRepository:WriteRepository<Domain.Entities.Menu>,IMenuWriteRepository
{
    public MenuWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}