using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.Commands.Order.CreateOrder;

namespace ShoppingApp.Presentation.Controllers
{
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
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse createOrderCommandResponse = await _mediator.Send(createOrderCommandRequest);

            return Ok(createOrderCommandResponse);
            
        }
        
    }
}
