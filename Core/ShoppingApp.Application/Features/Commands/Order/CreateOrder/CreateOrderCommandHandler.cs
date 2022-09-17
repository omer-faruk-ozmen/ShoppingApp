using MediatR;
using ShoppingApp.Application.Abstractions.Hubs;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommandRequest,CreateOrderCommandResponse>
{
    private readonly IOrderService _orderService;
    private readonly IBasketService _basketService;
    private readonly IOrderHubService _orderHubService;

    public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService)
    {
        _orderService = orderService;
        _basketService = basketService;
        _orderHubService = orderHubService;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
         await _orderService.CreateOrderAsync(new()
        {
            Address = request.Address,
            Description = request.Description,
            BasketId =  _basketService.GetUserActiveBasket?.Id.ToString()
        });

        await _orderHubService.OrderAddedMessageAsync("Hey!, A new order has been created.");

        return new()
        {
        };
    }
}