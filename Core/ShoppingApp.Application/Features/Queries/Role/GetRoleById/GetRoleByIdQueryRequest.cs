using MediatR;

namespace ShoppingApp.Application.Features.Queries.Role.GetRoleById;

public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
{
    public string Id { get; set; }
}