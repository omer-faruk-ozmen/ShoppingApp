using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderService _orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            ListOrder listOrder = await _orderService.GetAllOrdersAsync(request.Page, request.Size);

            return new()
            {
                TotalOrderCount = listOrder.TotalOrderCount,
                Orders = listOrder.Orders
            };
        }
    }
}
