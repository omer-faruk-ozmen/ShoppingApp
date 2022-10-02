using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.VerifyResetToken;

public class VerifyResetTokenCommandRequest :IRequest<VerifyResetTokenCommandResponse>
{
    public string UserId { get; set; }
    public string ResetToken { get; set; }
}