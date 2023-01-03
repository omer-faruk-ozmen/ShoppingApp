﻿namespace ShoppingApp.Application.ViewModels.Products;

public class UpdateProductViewModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}