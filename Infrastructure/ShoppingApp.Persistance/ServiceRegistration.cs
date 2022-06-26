using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Application.Repositories.File;
using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Application.Repositories.FileRepositories.InvoiceFile;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Persistence.Repositories.Customer;
using ShoppingApp.Persistence.Repositories.File;
using ShoppingApp.Persistence.Repositories.File.InvoiceFile;
using ShoppingApp.Persistence.Repositories.File.ProductImageFile;
using ShoppingApp.Persistence.Repositories.Order;
using ShoppingApp.Persistence.Repositories.Product;

namespace ShoppingApp.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ShoppingAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

        }
    }
}
