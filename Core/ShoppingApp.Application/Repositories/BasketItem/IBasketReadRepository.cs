using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Repositories.BasketItem
{
    public interface IBasketItemReadRepository : IReadRepository<Domain.Entities.BasketItem>
    {
    }
}
