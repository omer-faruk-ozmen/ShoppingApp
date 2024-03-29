﻿using MediatR;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Application.Features.Commands.AuthenticationEndpoint.AssignRoleEndpoint;

public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
{
    private readonly IAuthorizationEndpointService _authorizationEndpointService;

    public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
    {
        _authorizationEndpointService = authorizationEndpointService;
    }

    public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
    {
        await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);

        return new()
        {

        };
    }
}