using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Application.Features.Commands.AppUser.CreateUser;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            }, model.Password);

            CreateUserResponseDto response = new () { Succeeded = result.Succeeded };

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
        }
    }
}
