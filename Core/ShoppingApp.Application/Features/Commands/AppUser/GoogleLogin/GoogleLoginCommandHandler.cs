using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Abstractions.Token;
using ShoppingApp.Application.DTOs;

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
