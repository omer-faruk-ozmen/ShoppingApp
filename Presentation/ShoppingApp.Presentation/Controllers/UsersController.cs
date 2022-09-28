using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailService _mailService;

        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMail()
        {
            await _mailService.SendMessageAsync("ofotest@hotmail.com", "Onemli Bilgilendirme", "<p>Deneme</p>");
            return Ok();
        }
    }
}
