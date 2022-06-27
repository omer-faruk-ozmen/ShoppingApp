using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Abstractions.Storage;
using ShoppingApp.Infrastructure.Enums;
using ShoppingApp.Infrastructure.Services;
using ShoppingApp.Infrastructure.Services.Storage;
using ShoppingApp.Infrastructure.Services.Storage.Azure;
using ShoppingApp.Infrastructure.Services.Storage.Local;

namespace ShoppingApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage,IStorage
        {
            serviceCollection.AddScoped<IStorage,T>();
        }
        //A dirty code has been used at this point. the reason is to create an overloading mechanism for add storage<T>.
        public static void AddStorage<T>(this IServiceCollection serviceCollection,StorageType storageType) where T : class, IStorage
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }

        }
    }
}
