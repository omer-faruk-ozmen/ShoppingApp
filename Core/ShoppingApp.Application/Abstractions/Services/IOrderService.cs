using ShoppingApp.Application.DTOs.Orders;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<ListOrder> GetAllOrdersAsync(int page,int size);
        Task<SingleOrder> GetOrderByIdAsync(string id);
    }
}
