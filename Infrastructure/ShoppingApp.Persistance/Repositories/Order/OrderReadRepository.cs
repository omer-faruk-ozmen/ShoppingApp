using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
