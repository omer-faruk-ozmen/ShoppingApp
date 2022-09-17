using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;
using ShoppingApp.Application.Repositories.Order;

namespace ShoppingApp.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrderDto.Address,
                Id = Guid.Parse(createOrderDto.BasketId) ,
                Description = createOrderDto.Description
            });

            await _orderWriteRepository.SaveAsync();
        }
    }
}
