using MediatR;

namespace ShoppingApp.Application.Features.Commands.Basket.RemoveBasketItem;

public class RemoveBasketItemCommandRequest:IRequest<RemoveBasketItemCommandResponse>
{
    public string BasketItemId { get; set; }
}