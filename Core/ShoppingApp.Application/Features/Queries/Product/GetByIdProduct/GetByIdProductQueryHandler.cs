using MediatR;
using ShoppingApp.Application.Repositories.Product;
using P = ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {


            P.Product? product = await _productReadRepository.GetByIdAsync(request.Id!, false);

            if (product != null)
            {
                return new()
                {
                    Name = product.Name!,
                    Price = product.Price,
                    Stock = product.Stock,
                };
            }

            throw new Exception("Products are faulty ");


        }
    }
}
