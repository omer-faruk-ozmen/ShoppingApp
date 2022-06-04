using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
