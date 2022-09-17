using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string? UsernameOrEmail { get; set; }

        public string? Password { get; set; }
    }
}
