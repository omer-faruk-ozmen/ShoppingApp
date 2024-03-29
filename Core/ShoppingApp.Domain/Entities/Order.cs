﻿using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Domain.Entities;

public class Order : BaseEntity
{
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string OrderCode { get; set; }
    public Basket Basket { get; set; }
    public CompletedOrder CompletedOrder { get; set; }

}