﻿using ShoppingApp.Application.ViewModels.Baskets;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Abstractions.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemsAsync();
    public Task AddItemToBasketAsync(CreateBasketItemViewModel basketItem);
    public Task UpdateQuantityAsync(UpdateBasketItemViewModel basketItem);
    public Task RemoveBasketItemAsync(string basketItemId);
    public Basket?  GetUserActiveBasket { get; }
}