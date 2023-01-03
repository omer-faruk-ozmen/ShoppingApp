using ShoppingApp.Application.Repositories.Endpoint;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Endpoint;

public class EndpointReadRepository :ReadRepository<Domain.Entities.Endpoint>,IEndpointReadRepository
{
    public EndpointReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}