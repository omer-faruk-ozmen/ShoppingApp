using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Application.Exceptions;
using ShoppingApp.Domain.Entities.Identity;
using ShoppingApp.Application.Helpers;
using ShoppingApp.Application.Repositories.Endpoint;
using ShoppingApp.Persistence.Repositories.Endpoint;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEndpointReadRepository _endpointReadRepository;

    public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository)
    {
        _userManager = userManager;
        _endpointReadRepository = endpointReadRepository;
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

    public async Task<string[]> GetRolesToUserAsync(string idOrName)
    {
        AppUser user = await _userManager.FindByIdAsync(idOrName);
        if (user is null)
        {
            user = await _userManager.FindByNameAsync(idOrName);
        }
        if (user is not null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }

        return new string[] { };
    }

    public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
    {
        var userRoles = await GetRolesToUserAsync(name);

        if (!userRoles.Any())
            return false;

        Endpoint? endpoint = await _endpointReadRepository.Table
             .Include(e => e.AppRoles)
             .FirstOrDefaultAsync(e => e.Code == code);

        if (endpoint is null)
            return false;

        var endpointRoles = endpoint.AppRoles.Select(r => r.Name);

        foreach (var userRole in userRoles)
        {
            foreach (var endpointRole in endpointRoles)
                if (userRole == endpointRole)
                    return true;
        }

        return false;

    }
}