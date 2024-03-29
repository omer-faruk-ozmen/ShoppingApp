﻿using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Abstractions.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
    Task<bool> UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDateTime);

    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    Task<List<ListUserDto>> GetAllUsersAsync(int page,int size);
    int TotalUsersCount { get; }

    Task AssignRoleToUserAsync(string id, string[] roles);
    Task<string[]> GetRolesToUserAsync(string idOrName);
    Task<bool> HasRolePermissionToEndpointAsync(string name,string code);
}