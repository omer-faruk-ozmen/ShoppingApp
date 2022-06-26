using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File.ProductImageFile
{
    public class ProductImageFileReadRepository :ReadRepository<Domain.Entities.File.ProductImageFile>,IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
