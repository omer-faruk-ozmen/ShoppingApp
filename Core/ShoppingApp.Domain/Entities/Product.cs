using ShoppingApp.Domain.Entities.Common;
using ShoppingApp.Domain.Entities.File;

namespace ShoppingApp.Domain.Entities;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<ProductImageFile>? ProductImageFiles { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}