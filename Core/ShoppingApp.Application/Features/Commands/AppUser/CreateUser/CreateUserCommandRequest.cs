using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirm { get; set; }
}