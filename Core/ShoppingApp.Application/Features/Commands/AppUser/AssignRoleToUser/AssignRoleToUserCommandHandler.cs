using MediatR;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Application.Features.Commands.AppUser.AssignRoleToUser;

public class AssignRoleToUserCommandHandler:IRequestHandler<AssignRoleToUserCommandRequest,AssignRoleToUserCommandResponse>
{
    private readonly IUserService _userService;

    public AssignRoleToUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
    {

        await _userService.AssignRoleToUserAsync(request.Id, request.Roles);
        return new();
    }
}