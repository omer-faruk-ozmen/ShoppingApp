using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
