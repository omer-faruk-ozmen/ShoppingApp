using ShoppingApp.Application.DTOs.Orders;

namespace ShoppingApp.Application.Abstractions.Services;

public interface IOrderService
{
    Task CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<ListOrderDto> GetAllOrdersAsync(int page, int size);
    Task<SingleOrderDto> GetOrderByIdAsync(string id);
    Task<(bool,CompletedOrderDto)> CompleteOrderAsync(string id);
}