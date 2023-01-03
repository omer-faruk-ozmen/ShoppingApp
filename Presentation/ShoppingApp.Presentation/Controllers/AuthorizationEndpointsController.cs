using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.Commands.AuthenticationEndpoint.AssignRoleEndpoint;
using ShoppingApp.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationEndpointsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorizationEndpointsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("get-roles-to-endpoint")]
    public async Task<IActionResult> GetRolesToEndpoint( GetRolesToEndpointQueryRequest request)
    {
        GetRolesToEndpointQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest request)
    {
        request.Type = typeof(Program);
        AssignRoleEndpointCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}