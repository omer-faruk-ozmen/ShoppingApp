using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Application.Exceptions;
using ShoppingApp.Domain.Entities.Identity;
using System.Text;
using ShoppingApp.Application.Helpers;

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

            CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

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

        public async Task<bool> UpdateRefreshTokenAsync(string refreshToken, AppUser? user, DateTime accessTokenDate, int addOnAccessTokenDateTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDateTime);
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                throw new NotFoundUserException();
            }



        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }
    }
}
