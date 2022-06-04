using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
