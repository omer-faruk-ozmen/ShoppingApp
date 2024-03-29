﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Abstractions.Services.Authentication;
using ShoppingApp.Application.Repositories.Basket;
using ShoppingApp.Application.Repositories.BasketItem;
using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Application.Repositories.Endpoint;
using ShoppingApp.Application.Repositories.File;
using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Application.Repositories.FileRepositories.InvoiceFile;
using ShoppingApp.Application.Repositories.Menu;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Domain.Entities.Identity;
using ShoppingApp.Persistence.Repositories.Basket;
using ShoppingApp.Persistence.Repositories.BasketItem;
using ShoppingApp.Persistence.Repositories.CompletedOrder;
using ShoppingApp.Persistence.Repositories.Customer;
using ShoppingApp.Persistence.Repositories.Endpoint;
using ShoppingApp.Persistence.Repositories.File;
using ShoppingApp.Persistence.Repositories.File.InvoiceFile;
using ShoppingApp.Persistence.Repositories.File.ProductImageFile;
using ShoppingApp.Persistence.Repositories.Menu;
using ShoppingApp.Persistence.Repositories.Order;
using ShoppingApp.Persistence.Repositories.Product;
using ShoppingApp.Persistence.Services;

namespace ShoppingApp.Persistence;

public static class ServiceRegistration
{

    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ShoppingAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));


        var seedData = new SeedData();
        seedData.SeedAsync().GetAwaiter().GetResult();

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ShoppingAppDbContext>().AddDefaultTokenProviders();

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

        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

        services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
        services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();

        services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
        services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

        services.AddScoped<IMenuReadRepository, MenuReadRepository>();
        services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();


        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExternalAuthentication, AuthService>();
        services.AddScoped<IInternalAuthentication, AuthService>();

        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
    }
}