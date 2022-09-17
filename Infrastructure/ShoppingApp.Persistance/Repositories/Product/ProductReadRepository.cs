using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
