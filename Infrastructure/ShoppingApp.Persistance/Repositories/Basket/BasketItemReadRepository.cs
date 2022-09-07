using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.Basket;
using ShoppingApp.Application.Repositories.BasketItem;
using ShoppingApp.Application.Repositories.Customer;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Basket;

public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
{
    public BasketReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}