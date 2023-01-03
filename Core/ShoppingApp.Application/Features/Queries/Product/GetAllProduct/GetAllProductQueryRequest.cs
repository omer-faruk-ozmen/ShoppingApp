using MediatR;

namespace ShoppingApp.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryRequest :IRequest<GetAllProductQueryResponse>
{
    //public Pagination pagination { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}