using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Domain.Entities;

public class Order : BaseEntity
{
    public string? Description { get; set; }
    public string? Address { get; set; }
    public Basket Basket { get; set; }

}