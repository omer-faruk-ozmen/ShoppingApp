﻿using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Abstractions.Services.Configurations;
using ShoppingApp.Application.Abstractions.Storage;
using ShoppingApp.Application.Abstractions.Token;
using ShoppingApp.Infrastructure.Enums;
using ShoppingApp.Infrastructure.Services;
using ShoppingApp.Infrastructure.Services.Configurations;
using ShoppingApp.Infrastructure.Services.Storage;
using ShoppingApp.Infrastructure.Services.Storage.Azure;
using ShoppingApp.Infrastructure.Services.Storage.Local;
using TokenHandler = ShoppingApp.Infrastructure.Services.Token.TokenHandler;

namespace ShoppingApp.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        serviceCollection.AddScoped<IQrCodeService, QrCodeService>();
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
    //A dirty code has been used at this point. the reason is to create an overloading mechanism for add storage<T>.
    public static void AddStorage<T>(this IServiceCollection serviceCollection, StorageType storageType) where T : class, IStorage
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