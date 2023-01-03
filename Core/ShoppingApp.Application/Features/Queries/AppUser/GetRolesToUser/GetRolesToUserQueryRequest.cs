using MediatR;

namespace ShoppingApp.Application.Features.Queries.AppUser.GetRolesToUser;

public class GetRolesToUserQueryRequest:IRequest<GetRolesToUserQueryResponse>
{
    public string id { get; set; }
}