﻿using ShoppingApp.Application.Enums;

namespace ShoppingApp.Application.DTOs.Configurations;

public class Action
{
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }
}