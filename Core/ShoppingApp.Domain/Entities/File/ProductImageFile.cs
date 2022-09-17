namespace ShoppingApp.Domain.Entities.File;

public class ProductImageFile : File
{
    public bool Showcase { get; set; }
    public ICollection<Product> Products { get; set; }
}