using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ShoppingApp.Application.Abstractions.Hubs;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<CreateProductCommandHandler> logger, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _logger = logger;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            });
            await _productWriteRepository.SaveAsync();

            _logger.LogInformation("Product Added!");

            await _productHubService.ProductAddedMessageAsync($"Product named {request.Name} has been added");

            return new();
        }
    }
}
