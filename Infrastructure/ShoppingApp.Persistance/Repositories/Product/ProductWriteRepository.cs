using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}