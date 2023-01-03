using MediatR;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Features.Queries.Order.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    private readonly IOrderService _orderService;

    public GetOrderByIdQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        SingleOrderDto data = await _orderService.GetOrderByIdAsync(request.Id);
        return new()
        {
            Id = data.Id,
            OrderCode = data.OrderCode,
            Address = data.Address,
            BasketItems = data.BasketItems,
            CreatedDate = data.CreatedDate,
            UpdatedDate = data.UpdatedDate,
            Description = data.Description,
            Completed = data.Completed
        };
    }
}