using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File.ProductImageFile;

public class ProductImageFileReadRepository :ReadRepository<Domain.Entities.File.ProductImageFile>,IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}