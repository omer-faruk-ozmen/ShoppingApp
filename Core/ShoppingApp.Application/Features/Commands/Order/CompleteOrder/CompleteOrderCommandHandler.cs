using MediatR;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;
using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Application.Repositories.Order;

namespace ShoppingApp.Application.Features.Commands.Order.CompleteOrder;

public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
{
    private readonly IOrderService _orderService;
    private readonly IMailService _mailService;

    public CompleteOrderCommandHandler(IOrderService orderService, IMailService mailService)
    {
        _orderService = orderService;
        _mailService = mailService;
    }

    public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        (bool succeded, CompletedOrderDto dto) result = await _orderService.CompleteOrderAsync(request.Id.ToString());

        if (result.succeded)
            await _mailService.SendCompletedOrderMailAsync(result.dto.User, result.dto.OrderCode, result.dto.OrderDate);


        return new();
    }
}