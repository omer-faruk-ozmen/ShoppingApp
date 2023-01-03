using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.Enums;
using ShoppingApp.Application.Features.Commands.AppUser.AssignRoleToUser;
using ShoppingApp.Application.Features.Commands.AppUser.CreateUser;
using ShoppingApp.Application.Features.Commands.AppUser.UpdatePassword;
using ShoppingApp.Application.Features.Queries.AppUser.GetAllUsers;
using ShoppingApp.Application.Features.Queries.AppUser.GetRolesToUser;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest request)
    {
        UpdatePasswordCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("get-all-users")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetAllUsers", Menu = "Users")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest request)
    {
        GetAllUsersQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("assign-role-to-user")]

    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "AssignRoleToUser", Menu = "Users")]
    public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest request)
    {
        AssignRoleToUserCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("get-roles-to-user/{Id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetRolesToUser", Menu = "Users")]
    public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest request)
    {
        GetRolesToUserQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}