using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.CompletedOrder;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.CompletedOrder
{
    public class CompletedOrderWriteRepository : WriteRepository<Domain.Entities.CompletedOrder>,ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
