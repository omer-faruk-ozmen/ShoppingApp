using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingApp.Application.Abstractions;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Domain.Entities;
using IProductService = ShoppingApp.Application.Abstractions.Services.IProductService;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ShoppingApp.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IQrCodeService _qrCodeService;

        public ProductService(IProductReadRepository productReadRepository, IQrCodeService qrCodeService)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qrCodeService;
        }


        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product? product = await _productReadRepository.GetByIdAsync(productId);

            if (product is null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedDate
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return _qrCodeService.GenerateQrCode(plainText);

        }
    }
}
