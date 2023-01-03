using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Application.Exceptions;
using ShoppingApp.Domain.Entities.Identity;
using ShoppingApp.Application.Helpers;

namespace ShoppingApp.Persistence.Services;

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

    public async Task<List<ListUserDto>> GetAllUsersAsync(int page, int size)
    {
        List<AppUser> users = await _userManager.Users.Skip(page * size).Take(size).ToListAsync();

        return users.Select(user => new ListUserDto()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            UserName = user.UserName,
            TwoFactorEnabled = user.TwoFactorEnabled,
        }).ToList();
    }

    public int TotalUsersCount => _userManager.Users.Count();
    public async Task AssignRoleToUserAsync(string id, string[] roles)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        if (user is not null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, roles);
        }

    }

    public async Task<string[]> GetRolesToUserAsync(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        if (user is not null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }

        return new string[] { };
    }
}