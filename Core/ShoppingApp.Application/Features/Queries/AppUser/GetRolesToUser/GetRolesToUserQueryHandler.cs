using MediatR;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Application.Features.Queries.AppUser.GetRolesToUser;

public class GetRolesToUserQueryHandler : IRequestHandler<GetRolesToUserQueryRequest, GetRolesToUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetRolesToUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetRolesToUserQueryResponse> Handle(GetRolesToUserQueryRequest request, CancellationToken cancellationToken)
    {
        var userRoles = await _userService.GetRolesToUserAsync(request.id);
        return new()
        {
            UserRoles = userRoles
        };
    }
}