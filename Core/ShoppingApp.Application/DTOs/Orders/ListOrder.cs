﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.DTOs.Orders
{
    public class ListOrder
    {
        public int TotalOrderCount { get; set; }
        public object Orders { get; set; }
    }
}
