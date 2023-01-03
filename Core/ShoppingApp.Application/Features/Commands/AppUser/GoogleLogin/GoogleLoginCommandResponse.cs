using ShoppingApp.Application.DTOs;

namespace ShoppingApp.Application.Features.Commands.AppUser.GoogleLogin;

public class GoogleLoginCommandResponse
{
    public Token? Token { get; set; }
}