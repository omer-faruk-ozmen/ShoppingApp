using MediatR;

namespace ShoppingApp.Application.Features.Queries.Basket.GetBasketItems;

public class GetBasketItemsQueryRequest: IRequest<List<GetBasketItemsQueryResponse> >
{
}