using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
    }
}
