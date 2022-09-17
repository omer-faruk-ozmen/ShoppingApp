using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Domain.Entities;

public class Customer : BaseEntity
{
    public string? Name { get; set; }
    
}