using Microsoft.AspNetCore.SignalR;
using ShoppingApp.Application.Abstractions.Hubs;
using ShoppingApp.SignalR.Hubs;

namespace ShoppingApp.SignalR.HubServices
{
    public class OrderHubService : IOrderHubService
    {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OrderAddedMessageAsync(string message)
            => await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.OrderAddedMessage,message);
    }
}
