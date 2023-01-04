using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Consts;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.Enums;
using ShoppingApp.Application.Features.Commands.Order.CompleteOrder;
using ShoppingApp.Application.Features.Commands.Order.CreateOrder;
using ShoppingApp.Application.Features.Commands.Order.RemoveOrder;
using ShoppingApp.Application.Features.Queries.Order.GetAllOrders;
using ShoppingApp.Application.Features.Queries.Order.GetOrderById;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Create Order")]
    public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
    {
        CreateOrderCommandResponse createOrderCommandResponse = await _mediator.Send(createOrderCommandRequest);

        return Ok(createOrderCommandResponse);

    }

    [HttpGet]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get All Orders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrderQueryRequest getAllOrderQueryRequest)
    {
        GetAllOrderQueryResponse response = await _mediator.Send(getAllOrderQueryRequest);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order By Id")]
    public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
    {
        GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
        return Ok(response);
    }

    [HttpGet("complete-order/{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Complete Order")]
    public async Task<IActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
    {
        CompleteOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition = "Delete Order")]
    public async Task<IActionResult> DeleteOrder([FromRoute] RemoveOrderCommandRequest request)
    {
        RemoveOrderCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}