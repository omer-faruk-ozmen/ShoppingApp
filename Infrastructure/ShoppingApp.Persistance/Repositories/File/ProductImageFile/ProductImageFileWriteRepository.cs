using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File.ProductImageFile
{
    public class ProductImageFileWriteRepository:WriteRepository<Domain.Entities.File.ProductImageFile>,IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
