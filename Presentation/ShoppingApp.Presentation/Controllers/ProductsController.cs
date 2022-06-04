using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Abstractions;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id=Guid.NewGuid(),
                    Name = "Product 1",
                    Price = 100,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Name = "Product 2",
                    Price = 20,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Name = "Product 3",
                    Price = 233,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Name = "Product 4",
                    Price = 122,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 1244,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                }
            });
            var count = await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
