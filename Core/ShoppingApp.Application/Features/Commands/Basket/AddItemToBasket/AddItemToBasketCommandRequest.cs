using MediatR;

namespace ShoppingApp.Application.Features.Commands.Basket.AddItemToBasket;

public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}