using ShoppingApp.Application.DTOs.User;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
        Task<bool> UpdateRefreshToken(string refreshToken,AppUser user,DateTime accessTokenDate, int addOnAccessTokenDateTime);
    }
}
