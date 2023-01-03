using ShoppingApp.Application.Repositories.Endpoint;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.Endpoint;

public class EndpointWriteRepository : WriteRepository<Domain.Entities.Endpoint>, IEndpointWriteRepository
{
    public EndpointWriteRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}