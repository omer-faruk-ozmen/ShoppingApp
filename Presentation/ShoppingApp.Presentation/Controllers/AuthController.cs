using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.Commands.AppUser.GoogleLogin;
using ShoppingApp.Application.Features.Commands.AppUser.LoginUser;
using ShoppingApp.Application.Features.Commands.AppUser.PasswordReset;
using ShoppingApp.Application.Features.Commands.AppUser.RefreshTokenLogin;
using ShoppingApp.Application.Features.Commands.AppUser.VerifyResetToken;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
    {
        RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
        return Ok(response);
    }

        

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
    {
        LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
    {
        GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);

        return Ok(response);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest request)
    {
        PasswordResetCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("verify-reset-token")]
    public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest request)
    {
        VerifyResetTokenCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}