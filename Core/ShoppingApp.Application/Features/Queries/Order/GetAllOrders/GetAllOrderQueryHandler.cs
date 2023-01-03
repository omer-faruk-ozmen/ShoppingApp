using MediatR;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Features.Queries.Order.GetAllOrders;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
{
    private readonly IOrderService _orderService;

    public GetAllOrderQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        ListOrderDto listOrder = await _orderService.GetAllOrdersAsync(request.Page, request.Size);

        return new()
        {
            TotalOrderCount = listOrder.TotalOrderCount,
            Orders = listOrder.Orders
        };
    }
}