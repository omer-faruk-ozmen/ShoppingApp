using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using User = ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<User.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<User.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            }, request.Password);

            CreateUserCommandResponse response = new CreateUserCommandResponse(){Succeeded = result.Succeeded};

            if (result.Succeeded)
            {
                response.Message = "User successfully created";
            }

            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }
            return response;

            //throw new UserCreateFailedException();
        }
    }
}
