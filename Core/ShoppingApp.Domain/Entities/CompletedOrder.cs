using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Domain.Entities;

public class CompletedOrder : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}