using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.Commands.AppUser.CreateUser;
using ShoppingApp.Application.Features.Commands.AppUser.GoogleLogin;
using ShoppingApp.Application.Features.Commands.AppUser.LoginUser;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
    }
}
