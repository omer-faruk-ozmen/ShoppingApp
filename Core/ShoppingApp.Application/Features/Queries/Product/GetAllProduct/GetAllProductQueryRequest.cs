using MediatR;

namespace ShoppingApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest :IRequest<GetAllProductQueryResponse>
    {
        //public Pagination pagination { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
