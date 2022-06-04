using ShoppingApp.Application.Abstractions;
using ShoppingApp.Persistence.Concretes;

namespace ShoppingApp.Presentation
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
