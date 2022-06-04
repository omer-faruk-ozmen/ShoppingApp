using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
