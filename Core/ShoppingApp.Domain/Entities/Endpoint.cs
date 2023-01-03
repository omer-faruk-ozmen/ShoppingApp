using ShoppingApp.Domain.Entities.Common;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Domain.Entities;

public class Endpoint : BaseEntity
{
    public Endpoint()
    {
        AppRoles = new HashSet<AppRole>();
    }
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }
    public Menu Menu { get; set; }
    public ICollection<AppRole> AppRoles { get; set; }

}