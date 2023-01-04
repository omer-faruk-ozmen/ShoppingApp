using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShoppingApp.Application.Repositories.Order;

namespace ShoppingApp.Application.Features.Commands.Order.RemoveOrder;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest,RemoveOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public RemoveOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<RemoveOrderCommandResponse> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderWriteRepository.RemoveAsync(request.Id);
        await _orderWriteRepository.SaveAsync();

        return new ();
    }
}