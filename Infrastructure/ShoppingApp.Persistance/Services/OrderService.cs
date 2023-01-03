using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.Orders;
using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;
    private readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
    private readonly ICompletedOrderReadRepository _completedOrderReadRepository;
    public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
        _completedOrderWriteRepository = completedOrderWriteRepository;
        _completedOrderReadRepository = completedOrderReadRepository;
    }

    public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        string orderCode = (new Random().NextDouble()).ToString();
        orderCode = orderCode.Substring(orderCode.IndexOf(",") + 1, 12);

        await _orderWriteRepository.AddAsync(new()
        {
            Id = Guid.Parse(createOrderDto.BasketId),
            Address = createOrderDto.Address,
            Description = createOrderDto.Description,
            OrderCode = orderCode
        });

        await _orderWriteRepository.SaveAsync();
    }

    public async Task<ListOrder> GetAllOrdersAsync(int page, int size)
    {
        var query = _orderReadRepository.Table.Include(o => o.Basket)
            .ThenInclude(b => b.User)
            .Include(o => o.Basket)
            .ThenInclude(b => b.BasketItems)
            .ThenInclude(bi => bi.Product);

        var data = query.Skip(page * size).Take(size).OrderByDescending(o => o.CreatedDate);

        var data1 = from order in data
            join completedOrder in _completedOrderReadRepository.Table on order.Id equals completedOrder.OrderId into co
            from _co in co.DefaultIfEmpty()
            select new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                OrderCode = order.OrderCode,
                Basket = order.Basket,
                Completed = _co != null ? true : false,
            };

        return new()
        {
            TotalOrderCount = await query.CountAsync(),
            Orders = await data1.Select(o => new
            {
                Id = o.Id,
                CreatedDate = o.CreatedDate,
                OrderCode = o.OrderCode,
                TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                Username = o.Basket.User.UserName,
                o.Completed
            }).ToListAsync()
        };
    }

    public async Task<SingleOrder> GetOrderByIdAsync(string id)
    {
        var data = _orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.BasketItems)
            .ThenInclude(bi => bi.Product);



        //
        var data1 = await (from order in data
            join completedOrder in _completedOrderReadRepository.Table on order.Id equals completedOrder
                .OrderId into co
            from _co in co.DefaultIfEmpty()
            select new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                UpdatedDate = order.UpdatedDate,
                OrderCode = order.OrderCode,
                Basket = order.Basket,
                Completed = _co != null ? true : false,
                Address = order.Address,
                Description = order.Description,
            }).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id)); ;


        return new()
        {
            Id = data1.Id.ToString(),
            OrderCode = data1.OrderCode,
            BasketItems = data1.Basket.BasketItems.Select(bi => new
            {
                bi.Product.Name,
                bi.Product.Price,
                bi.Quantity
            }),
            Description = data1.Description,
            Address = data1.Address,
            CreatedDate = data1.CreatedDate,
            UpdatedDate = data1.UpdatedDate,
            Completed = data1.Completed
        };
    }

    public async Task<(bool, CompletedOrderDto)> CompleteOrderAsync(string id)
    {
        Order? order = await _orderReadRepository.Table.Include(o => o.Basket)
            .ThenInclude(p => p.User)
            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));


        if (order != null)
        {
            await _completedOrderWriteRepository.AddAsync(new() { OrderId = Guid.Parse(id) });
                
            return (await _completedOrderWriteRepository.SaveAsync() > 0, new()
            {
                OrderCode = order.OrderCode,
                OrderDate = order.CreatedDate,
                User = order.Basket.User
            });
        }

        return (false,null);
    }
}