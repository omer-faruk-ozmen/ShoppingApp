using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Domain.Entities;

public class Menu : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Endpoint> Endpoints { get; set; }
}