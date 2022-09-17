using MediatR;
using ShoppingApp.Application.Repositories.Product;
using P= ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product? product = await _productReadRepository.GetByIdAsync(request.Id!);

            if (product != null)
            {
                product.Stock = request.Stock;
                product.Price = request.Price;
                product.Name = request.Name;
            }

            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
