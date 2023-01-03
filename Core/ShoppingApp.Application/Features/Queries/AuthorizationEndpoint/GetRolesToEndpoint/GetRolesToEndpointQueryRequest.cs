using MediatR;

namespace ShoppingApp.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint;

public class GetRolesToEndpointQueryRequest : IRequest<GetRolesToEndpointQueryResponse>
{
    public string Code { get; set; }
    public string Menu { get; set; }
}