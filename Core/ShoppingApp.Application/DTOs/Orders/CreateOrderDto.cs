﻿namespace ShoppingApp.Application.DTOs.Orders;

public class CreateOrderDto
{
    public string? BasketId { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
}