using Microsoft.AspNetCore.Builder;
using ShoppingApp.SignalR.Hubs;

namespace ShoppingApp.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication app)
        {
            app.MapHub<ProductHub>("/products-hub");
            app.MapHub<OrderHub>("/orders-hub");
        }
    }
}
