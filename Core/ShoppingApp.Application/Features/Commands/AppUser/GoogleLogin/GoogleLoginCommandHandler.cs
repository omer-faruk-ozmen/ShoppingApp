using MediatR;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {


            var token = await _authService.GoogleLoginAsync(request.IdToken!, request.Provider!, 10);

            return new()
            {
                Token = token
            };
        }
    }
}
