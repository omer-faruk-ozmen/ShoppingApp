using ShoppingApp.Application.Abstractions;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Persistence.Concretes;

public class ProductService : IProductService
{
    public List<Product> GetProducts() => new()
    {
            

        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 1",
            Price = 100,
            Stock = 10
        },
        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 2",
            Price = 20,
            Stock = 10
        },
        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 3",
            Price = 233,
            Stock = 10
        },
        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 4",
            Price = 122,
            Stock = 10
        },
        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 5",
            Price = 1244,
            Stock = 10
        },
        new()
        {
            Id=Guid.NewGuid(),
            Name = "Product 6",
            Price = 300,
            Stock = 10
        },
    };
}