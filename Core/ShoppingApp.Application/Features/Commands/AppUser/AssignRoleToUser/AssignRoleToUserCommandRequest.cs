using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.AssignRoleToUser;

public class AssignRoleToUserCommandRequest:IRequest<AssignRoleToUserCommandResponse>
{
    public string Id { get; set; }
    public string[] Roles { get; set;}
}