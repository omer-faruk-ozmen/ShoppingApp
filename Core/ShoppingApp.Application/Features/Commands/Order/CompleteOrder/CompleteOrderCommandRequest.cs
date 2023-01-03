using MediatR;

namespace ShoppingApp.Application.Features.Commands.Order.CompleteOrder;

public class CompleteOrderCommandRequest : IRequest<CompleteOrderCommandResponse>
{
    public Guid Id { get; set; }
}