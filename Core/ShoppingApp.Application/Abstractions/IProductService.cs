using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
