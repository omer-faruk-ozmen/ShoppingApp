using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Abstractions.Hubs;
using ShoppingApp.SignalR.HubServices;

namespace ShoppingApp.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddTransient<IOrderHubService, OrderHubService>();
            collection.AddSignalR();
        }
    }
}
