using MediatR;

namespace ShoppingApp.Application.Features.Commands.Order.RemoveOrder;

public class RemoveOrderCommandRequest : IRequest<RemoveOrderCommandResponse>
{
    public string Id { get; set; }
}