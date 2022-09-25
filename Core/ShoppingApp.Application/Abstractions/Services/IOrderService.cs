using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<ListOrder> GetAllOrdersAsync(int page,int size);
    }
}
