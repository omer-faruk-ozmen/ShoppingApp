﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities.File;

public class InvoiceFile:File
{
    public decimal Price { get; set; }
}