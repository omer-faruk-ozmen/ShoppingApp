using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.DTOs.Orders;

public class CompletedOrderDto
{
    public string OrderCode { get; set; }
    public DateTime OrderDate { get; set; }
    public AppUser User { get; set; }
        
}