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
            await _mailService.SendMessageAsync("yesilyayla3649@icloud.com", "Onemli Bilgilendirme", "<p><span style=\"color:#e74c3c\"><em><strong>Selam Bebek</strong></em></span></p>\r\n\r\n<p><span style=\"color:#f39c12\"><strong>Ben Kelebek</strong></span></p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<p><span style=\"color:#8e44ad\">Bu bir OFO uygulama testidir l&uuml;tfen sizi sevmesi dışında dikkate almayınız...</span></p>");
            return Ok();
        }
    }
}
