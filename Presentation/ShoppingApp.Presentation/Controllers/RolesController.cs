using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Consts;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.Enums;
using ShoppingApp.Application.Features.Commands.Role.CreateRole;
using ShoppingApp.Application.Features.Commands.Role.DeleteRole;
using ShoppingApp.Application.Features.Commands.Role.UpdateRole;
using ShoppingApp.Application.Features.Queries.Role.GetRoleById;
using ShoppingApp.Application.Features.Queries.Role.GetRoles;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest getRolesQueryRequest)
        {
            GetRolesQueryResponse response = await _mediator.Send(getRolesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles By Id", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetByIdRole([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        {
            GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
            return Ok(response);
        }

        [HttpDelete("{Name}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);

            return Ok(response);
        }


        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);

            return Ok(response);
        }


        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }
    }
}
