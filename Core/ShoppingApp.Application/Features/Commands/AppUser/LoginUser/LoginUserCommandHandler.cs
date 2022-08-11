using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Abstractions.Token;
using ShoppingApp.Application.DTOs;
using ShoppingApp.Application.Exceptions;
using U = ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;
        readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(IAuthService authService, ILogger<LoginUserCommandHandler> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Login User {request.UsernameOrEmail}");
            var token = await _authService.LoginAsync(request.UsernameOrEmail!, request.Password!, 10);

            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };

        }
    }
}
